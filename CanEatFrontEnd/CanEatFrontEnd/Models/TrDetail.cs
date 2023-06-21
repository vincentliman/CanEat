using CanEatFrontEnd.Models.DBModel;
using CanEatFrontEnd.Models.OtherDBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CanEatFrontEnd.Models
{
    public class TrDetail
    {
		public string trId {  get; set; }
        public Food Food { get; set; }
        public int Qty { get; set; }
        public string Notes { get; set; }

        public TrDetail() {
            Food = new Food();
        }
		private static HttpClientHandler _clientHandler;

		private static HttpClientHandler connect()
		{
			_clientHandler = new HttpClientHandler();
			_clientHandler.ServerCertificateCustomValidationCallback = (sender, cert
				, chain, SslPolicyErrors) => { return true; };
			return _clientHandler;
		}

		public static async Task<List<TrDetailModel>> getAllDetail()
		{
			List<TrDetailModel> _DetailList = new List<TrDetailModel>();
			List<TrDetail> detailList = new List<TrDetail>();
			using (var handler = connect())
			using (var client = new HttpClient(handler))
			{
				using (var response = await client.GetAsync("https://localhost:7082/api/TrDetail"))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					var data = JsonConvert.DeserializeObject<Dictionary<string, List<TrDetailModel>>>(apiResult);
					var shops = data["payload"];
					foreach (var i in shops)
					{
						_DetailList.Add(i);
					}
				}
			}

			//foreach (TrDetailModel c in _DetailList)
			//{
			//	TrDetail d = new TrDetail();
			//	d.trId = c.tr_id;
			//	d.Qty = c.qty;
			//	d.Notes = c.notes;
			//	d.Food = await Food.getFood(c.food_id);
			//	detailList.Add(d);
			//}
			return _DetailList;
		}

		public static async Task<List<TrDetail>> getDetailHeader(string id)
		{
			List<TrDetailModel> list = await getAllDetail();
			List<TrDetail> detailList = new List<TrDetail>();
			foreach(TrDetailModel c in list)
			{
                TrDetail d = new TrDetail();
                if (c.tr_id.Equals(id))
				{   
					d.trId = c.tr_id;
					d.Qty = c.qty;
					d.Notes = c.notes;
					d.Food = await Food.getFood(c.food_id);
					detailList.Add(d);
				}
			}
			return detailList;
		}

        [HttpPost]
        public static async Task<string> addDetail(DetailAddModel model)
        {
            string result = "";

            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7082/api/TrDetail", content))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(apiResult);
                    result = responseObject.message;
                }
            }
            return result;
        }
    }
}

using CanEatFrontEnd.Models.DBModel;
using CanEatFrontEnd.Models.OtherDBModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Text;

namespace CanEatFrontEnd.Models
{
    public class TrHeader
    {
        public string ID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public DateTime PickupDateTime { get; set; }
        public Boolean PaymentStatus { get; set; }
        public Boolean PickupStatus { get; set; }

        public Vendor Vendor { get; set; }
        public Customer Customer { get; set; }

        public List<TrDetail> detailList { get; set; }

        public TrHeader()
        {
            Vendor = new Vendor();
            Customer = new Customer();
            detailList = new List<TrDetail>();
        }

		private static HttpClientHandler _clientHandler;

		private static HttpClientHandler connect()
		{
			_clientHandler = new HttpClientHandler();
			_clientHandler.ServerCertificateCustomValidationCallback = (sender, cert
				, chain, SslPolicyErrors) => { return true; };
			return _clientHandler;
		}

		public static async Task<List<TrHeaderModel>> getAllHeader()
		{
			List<TrHeaderModel> _HeaderList = new List<TrHeaderModel>();
			List<TrHeader> headerList = new List<TrHeader>();
			using (var handler = connect())
			using (var client = new HttpClient(handler))
			{
				using (var response = await client.GetAsync("https://localhost:7082/api/TrHeader"))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					var data = JsonConvert.DeserializeObject<Dictionary<string, List<TrHeaderModel>>>(apiResult);
					var shops = data["payload"];
					foreach (var i in shops)
					{
						_HeaderList.Add(i);
					}
				}
			}

			//foreach (TrHeaderModel c in _HeaderList)
			//{
			//	TrHeader h = new TrHeader();
			//	h.ID = c.id;
			//	h.Vendor = await Vendor.getVendor(c.shop_id);
			//	h.Customer = await Customer.getCustomer(c.customer_id);
			//	h.PaymentStatus = c.paymentStatus;
			//	h.PickupDateTime = c.pickUpDateTime;
			//	h.TransactionDateTime = c.date;
			//	h.PaymentStatus = c.paymentStatus;
			//	h.PickupStatus = c.pickUpStatus;
			//	h.detailList = await TrDetail.getDetailHeader(c.id);
			//	headerList.Add(h);
			//}
			return _HeaderList;
		}

		public static async Task<TrHeader> getHeader(string id)
		{
			List<TrHeaderModel> headerList = await getAllHeader();
			TrHeaderModel header = headerList.Where(head => head.tr_id == id).FirstOrDefault();
			TrHeader returnedHeader = new TrHeader();
            returnedHeader.ID = header.tr_id;
            returnedHeader.Vendor = await Vendor.getVendor(header.shop_id);
			returnedHeader.Customer = await Customer.getCustomer(header.customer_id);
			returnedHeader.PickupDateTime = header.pickUpDateTime;
			returnedHeader.TransactionDateTime = header.date;
			returnedHeader.PickupStatus = header.pickUpStatus;
			returnedHeader.PaymentStatus = header.paymentStatus;
			returnedHeader.detailList = await TrDetail.getDetailHeader(id);
			return returnedHeader;
		}

		public static async Task<TrHeader> getLatestHeader(string customerId)
		{
            List<TrHeaderModel> headerList = await getAllHeader();
            TrHeaderModel header = headerList.Where(head => head.customer_id == customerId).OrderBy(head => head.pickUpDateTime).FirstOrDefault();
			if(header == null)
			{
				return null;
			}
			else
			{
                TrHeader returnedHeader = new TrHeader();
                returnedHeader.ID = header.tr_id;
                returnedHeader.Vendor = await Vendor.getVendor(header.shop_id);
                returnedHeader.Customer = await Customer.getCustomer(header.customer_id);
                returnedHeader.PickupDateTime = header.pickUpDateTime;
                returnedHeader.TransactionDateTime = header.date;
                returnedHeader.PickupStatus = header.pickUpStatus;
                returnedHeader.PaymentStatus = header.paymentStatus;
                returnedHeader.detailList = await TrDetail.getDetailHeader(header.tr_id);
                return returnedHeader;
            }
        }


        [HttpPost]
		public static async Task<string> addHeader(HeaderAddModel model)
		{
            string result = "";

            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7082/api/TrHeader", content))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(apiResult);
                    result = responseObject.message;
                }
            }
			return result;
        }

		public static async Task<List<TrHeader>> getHeaderVendor(string id)
		{
			List<TrHeaderModel> headerList = await getAllHeader();
			List<TrHeader> returnedList = new List<TrHeader>();
			foreach (TrHeaderModel c in headerList)
			{
				TrHeader h = new TrHeader();
				if (c.shop_id.Equals(id) && c.pickUpStatus == false)
				{
                    h.ID = c.tr_id;
                    h.Vendor = await Vendor.getVendor(c.shop_id);
                    h.Customer = await Customer.getCustomer(c.customer_id);
                    h.PaymentStatus = c.paymentStatus;
                    h.PickupDateTime = c.pickUpDateTime;
                    h.TransactionDateTime = c.date;
                    h.PaymentStatus = c.paymentStatus;
                    h.PickupStatus = c.pickUpStatus;
                    h.detailList = await TrDetail.getDetailHeader(c.tr_id);
                    returnedList.Add(h);
                }
			}
			return returnedList.OrderBy(h => h.PickupDateTime).ToList();
        }

		public static async Task<string> editHeader(HeaderEditModel model)
		{
            string result = "";
            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PatchAsync("https://localhost:7082/api/TrHeader", content))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject(apiResult).ToString();
                }
            }
            return result;
        }
	}
}

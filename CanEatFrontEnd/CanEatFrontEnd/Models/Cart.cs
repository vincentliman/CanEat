using CanEatFrontEnd.Models.DBModel;
using CanEatFrontEnd.Models.OtherDBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CanEatFrontEnd.Models
{
    public class Cart
    {
		public string customerId { get; set; }
        public Food Food { get; set; }
        public int Qty { get; set; }
        public string Notes { get; set; }
        
        public Cart() {
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

		[HttpGet]
		public static async Task<List<Cart>> getAllCart()
		{
			List<MsCartModel> _CartList = new List<MsCartModel>();
			List<Cart> cartList = new List<Cart>();
			using (var handler = connect())
			using (var client = new HttpClient(handler))
			{
				using (var response = await client.GetAsync("https://localhost:7082/api/Cart"))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					var data = JsonConvert.DeserializeObject<Dictionary<string, List<MsCartModel>>>(apiResult);
					var shops = data["payload"];
					foreach (var i in shops)
					{
						_CartList.Add(i);
					}
				}
			}

			foreach (MsCartModel c in _CartList)
			{
				Cart ca = new Cart();
				ca.customerId = c.customer_id;
				ca.Food = await Food.getFood(c.food_id);
				ca.Qty = Convert.ToInt32(c.qty);
				ca.Notes = c.notes;
				cartList.Add(ca);
			}
			return cartList;
		}

        public static async Task<List<Cart>> getCartCustomer(string id)
		{
			List<Cart> cartList = await getAllCart();
			return cartList.Where(cart => cart.customerId == id).ToList();
		}

		[HttpPost]
		public static async Task<String> addToCart(CartAddModel model)
		{
			Cart c = null;
            c = (await getAllCart()).Where(cart => cart.customerId == model.customer_id && cart.Food.Id == model.food_id).FirstOrDefault();
			if(c == null)
			{
                string result = "";

                using (var handler = connect())
                using (var client = new HttpClient(handler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    using (var response = await client.PostAsync("https://localhost:7082/api/Cart", content))
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject(apiResult).ToString();
                    }
                }
                return result;
			}
			else
			{
				CartDeleteItemModel modelEdit = new CartDeleteItemModel();
				modelEdit.qty = model.qty;
				modelEdit.notes = model.notes;
				modelEdit.customer_id = model.customer_id;
				modelEdit.food_id = model.food_id;
				return await deleteCartItems(modelEdit);
			}
            
        }

		[HttpPatch]
		public static async Task<string> deleteCartItems(CartDeleteItemModel model)
		{
            string result = "";
            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PatchAsync("https://localhost:7082/api/Cart", content))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject(apiResult).ToString();
                }
            }
            return result;
        }

		[HttpDelete]
		public static async Task<string> deleteAll(string id)
		{
            string result = "";
            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                using (var response = await client.DeleteAsync("https://localhost:7082/api/Cart/" + id))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject(apiResult).ToString();
                }
            }
            return result;
        }
	}
}

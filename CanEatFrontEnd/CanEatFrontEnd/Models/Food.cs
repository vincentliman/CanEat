using CanEatFrontEnd.Models.DBModel;
using CanEatFrontEnd.Models.OtherDBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CanEatFrontEnd.Models
{
    public class Food
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public decimal Rating { get; set; }
        public Vendor Vendor { get; set; }

        public Food()
        {
            Vendor = new Vendor();
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
        public static async Task<List<Food>> getAllFood()
        {
            List<MsFoodModel> _FoodList = new List<MsFoodModel>();
            List<Food> foodList = new List<Food>();

            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                using (var response = await client.GetAsync("https://localhost:7082/api/Food"))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    //_CustomerList = JsonConvert.DeserializeObject<JsonArray>(apiResult);
                    var data = JsonConvert.DeserializeObject<Dictionary<string, List<MsFoodModel>>>(apiResult);
                    var foods = data["payload"];
                    foreach (var i in foods)
                    {
                        _FoodList.Add(i);
                    }

                }
            }
            foreach (MsFoodModel f in _FoodList)
            {
                Food fo = new Food();
                fo.Id = f.id.ToString();
                fo.Name = f.name;
                fo.Price = f.price;
                fo.Description = f.description;
                fo.Vendor = await Vendor.getVendor(f.shop_id.ToString());
                foodList.Add(fo);
            }
            return foodList;
        }

        [HttpGet]
        public static async Task<Food> getFood(string id)
        {
            //MsFoodModel _Food = new MsFoodModel();
            //Food fo = new Food();

            //using (var handler = connect())
            //using (var client = new HttpClient(handler))
            //{
            //    using (var response = await client.GetAsync("https://localhost:7082/api/Customer/" + id))
            //    {
            //        string apiResult = await response.Content.ReadAsStringAsync();
            //        _Food = JsonConvert.DeserializeObject<MsFoodModel>(apiResult);
            //    }
            //}
            //fo.Id = _Food.id.ToString();
            //fo.Name = _Food.name;
            //fo.Price = _Food.price;
            //fo.Description = _Food.description;
            ////TODO: Vendor
            List<Food> listFood = await getAllFood();
            Food fo = listFood.Where(fo => fo.Id == id).FirstOrDefault();
            return fo;
        }

        public static async Task<List<Food>> getFoodVendor(string id)
        {
            List<Food> listFood = await getAllFood();
            listFood = listFood.Where(fo => fo.Vendor.Id == id).ToList();
            return listFood;
        }

        public static async Task<string> deleteFood(string id) 
        {
			string result = "";
			using (var handler = connect())
			using (var client = new HttpClient(handler))
			{
				using (var response = await client.DeleteAsync("https://localhost:7082/api/Food/" + id))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					result = JsonConvert.DeserializeObject(apiResult).ToString();
				}
			}
			return result;
		}

        [HttpPost]
        public static async Task<String> addFood(FoodAddModel model)
        {
			string result = "";

			using (var handler = connect())
			using (var client = new HttpClient(handler))
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
				using (var response = await client.PostAsync("https://localhost:7082/api/Food", content))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					result = JsonConvert.DeserializeObject(apiResult).ToString();
				}
			}
			return result;
		}

        [HttpPatch]
        public static async Task<string> editFood(FoodEditModel model)
        {
			string result = "";
			using (var handler = connect())
			using (var client = new HttpClient(handler))
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
				using (var response = await client.PatchAsync("https://localhost:7082/api/Food", content))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					result = JsonConvert.DeserializeObject(apiResult).ToString();
				}
			}
			return result;
		}
    }
}

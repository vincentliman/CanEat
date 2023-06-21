using CanEatFrontEnd.Models.DBModel;
using CanEatFrontEnd.Models.OtherDBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace CanEatFrontEnd.Models
{
    public class Vendor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Company Company { get; set; }
        public Boolean Status { get; set; }

        public Vendor() { 
            Company = new Company();
        }

        private static HttpClientHandler _clientHandler;

        private static HttpClientHandler connect()
        {
                _clientHandler = new HttpClientHandler();
                _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert
                    , chain, SslPolicyErrors) => { return true; };
            return _clientHandler;
        }

        public static async Task<List<Vendor>> getVendorCompany(string companyId)
        {
            List<Vendor> listVendor = await getAllVendor();
            listVendor = listVendor.Where(vendor => vendor.Company.Id == companyId).ToList();
            if (listVendor.Count <= 0)
            {
                listVendor = new List<Vendor>();
            }
            return listVendor;
        }

        public static async Task<List<Vendor>> getUnverified()
        {

            List<Vendor> listVendor = await getAllVendor();
            listVendor = listVendor.Where(vendor => vendor.Status == false).ToList();
            if(listVendor.Count <= 0) {
                listVendor = new List<Vendor>();
            }
            return listVendor;
        }

        [HttpGet]
        public static async Task<List<Vendor>> getAllVendor()
        {
            List<MsShopModel> _ShopList = new List<MsShopModel>();
            List<Vendor> vendorList = new List<Vendor>();
            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                using (var response = await client.GetAsync("https://localhost:7082/api/Shop"))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Dictionary<string, List<MsShopModel>>>(apiResult);
                    var shops = data["payload"];
                    foreach (var i in shops)
                    {
                        _ShopList.Add(i);
                    }
                }
            }

            foreach (MsShopModel s in _ShopList)
            {
                Vendor v = new Vendor();
                v.Id = s.id.ToString();
                v.Email = s.email;
                v.Name = s.name;
                v.Phone = s.phone;
                v.Password = s.password;
                v.Company = await Company.getCompany(s.company_id.ToString());
                v.Status = s.status;
                vendorList.Add(v);
            }
            return vendorList;
        }

        [HttpGet]
        public static async Task<Vendor> getVendor(string id)
        {
			//MsShopModel _Shop = new MsShopModel();
			//Vendor v = new Vendor();

			//using (var handler = connect())
			//using (var client = new HttpClient(handler))
			//{
			//    using (var response = await client.GetAsync("https://localhost:7082/api/Shop/" + Id))
			//    {
			//        string apiResult = await response.Content.ReadAsStringAsync();
			//        _Shop = JsonConvert.DeserializeObject<MsShopModel>(apiResult);
			//    }
			//}

			//v.Id = _Shop.id.ToString();
			//v.Email = _Shop.email;
			//v.Name = _Shop.name;
			//v.Phone = _Shop.phone;
			//v.Password = _Shop.password;
			//v.Company = await Company.getCompany(_Shop.company_id.ToString());
			//v.Status = _Shop.status;
			List<Vendor> listVendor = await getAllVendor();
			Vendor v = listVendor.Where(v => v.Id == id).FirstOrDefault();

			return v;
        }

        [HttpGet]
        public static async Task<String> login(string email, string pass)
        {
            //String id = "";
            //using (var handler = connect())
            //using (var client = new HttpClient(handler))
            //{
            //    using (var response = await client.GetAsync("https://localhost:7082/api/Shop/" + email + ", " + pass))
            //    {
            //        string apiResult = await response.Content.ReadAsStringAsync();
            //        //_CustomerList = JsonConvert.DeserializeObject<JsonArray>(apiResult);
            //        var data = JsonConvert.DeserializeObject<Dictionary<string, MsShopModel>>(apiResult);
            //        var user = data["payload2"];
            //        if (user != null)
            //        {
            //            id = user.id.ToString();
            //        }
            //        else
            //        {
            //            id = null;
            //        }
            //    }
            //}
            //return id;
            List<Vendor> listVendor = await getAllVendor();
            Vendor v = listVendor.Where(v => v.Email == email && v.Password == pass && v.Status == true).FirstOrDefault();

            if (v != null) return v.Id;
            else return null;
        }

        [HttpPost]
        public static async Task<string> vendorRegister(VendorRegisterModel model)
        {
            string result = "";

            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7082/api/Shop", content))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject(apiResult).ToString();
                }
            }
            return result;
        }

        [HttpDelete]
        public static async Task<string> deleteVendor(string id)
        {
			string result = "";
			using (var handler = connect())
			using (var client = new HttpClient(handler))
			{
				using (var response = await client.DeleteAsync("https://localhost:7082/api/Shop/" + id))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					result = JsonConvert.DeserializeObject(apiResult).ToString();
				}
			}
			return result;
		}
        [HttpPatch]
        public static async Task<string> editVendor(VendorEditModel model)
        {
			string result = "";
			using (var handler = connect())
			using (var client = new HttpClient(handler))
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
				using (var response = await client.PatchAsync("https://localhost:7082/api/Shop", content))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					result = JsonConvert.DeserializeObject(apiResult).ToString();
				}
			}
			return result;
		}
    }
}

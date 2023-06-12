using CanEatFrontEnd.Models.DBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpDelete]
        public static async Task<string> deleteVendor(string id)
        {
            return "";
        }
        [HttpPatch]
        public static async Task<string> editVendor()
        {
            return "";
        }
    }
}

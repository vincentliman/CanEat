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

        private static HttpClientHandler _clientHandler = new HttpClientHandler();

        private static void connect()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert
                , chain, SslPolicyErrors) => { return true; };
        }


        [HttpGet]
        public static async Task<List<Vendor>> getAllVendor()
        {
            List<MsShopModel> _ShopList = new List<MsShopModel>();
            List<Vendor> vendorList = new List<Vendor>();

            connect();
            using (var client = new HttpClient(_clientHandler))
            {
                using (var response = await client.GetAsync("https://localhost:7082/api/Shop"))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    _ShopList = JsonConvert.DeserializeObject<List<MsShopModel>>(apiResult);
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
                //v.Status = s. //TODO: add Status to DB Model
                vendorList.Add(v);
            }
            return vendorList;
        }

        [HttpGet]
        public static async Task<Vendor> getVendor(string Id)
        {
            MsShopModel _Shop = new MsShopModel();
            Vendor v = new Vendor();

            connect();
            using (var client = new HttpClient(_clientHandler))
            {
                using (var response = await client.GetAsync("https://localhost:7082/api/Shop/" + Id))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    _Shop = JsonConvert.DeserializeObject<MsShopModel>(apiResult);
                }
            }

            v.Id = _Shop.id.ToString();
            v.Email = _Shop.email;
            v.Name = _Shop.name;
            v.Phone = _Shop.phone;
            v.Password = _Shop.password;
            v.Company = await Company.getCompany(_Shop.company_id.ToString());
            //v.Status = s. //TODO: add Status to DB Model

            return v;
        }
    }
}

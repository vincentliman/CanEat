using CanEatFrontEnd.Models.DBModel;
using CanEatFrontEnd.Models.OtherDBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace CanEatFrontEnd.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Company()
        {
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
		public static async Task<List<Company>> getAllCompany()
		{
			List<MsCompanyModel> _CompanyList = new List<MsCompanyModel>();
			List<Company> companyList = new List<Company>();

            using (var handler = connect())
            using (var client = new HttpClient(handler))
			{
				using (var response = await client.GetAsync("https://localhost:7082/api/Company"))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Dictionary<string, List<MsCompanyModel>>>(apiResult);
                    var company = data["payload"];
                    foreach (var i in company)
                    {
                        _CompanyList.Add(i);
                    }
                }
			}

			foreach (MsCompanyModel c in _CompanyList)
			{
				Company co = new Company();
				co.Id = c.id.ToString();
				co.Address = c.address;
				co.Name = c.name;
				co.Phone = c.phone;
				companyList.Add(co);
			}
			return companyList;
		}

		[HttpGet]
		public static async Task<Company> getCompany(string Id)
		{
            //MsCompanyModel _Company = new MsCompanyModel();
            //Company co = new Company();

            //         using (var handler = connect())
            //         using (var client = new HttpClient(handler))
            //{
            //	using (var response = await client.GetAsync("https://localhost:7082/api/Company/" + Id))
            //	{
            //		string apiResult = await response.Content.ReadAsStringAsync();
            //                 var data = JsonConvert.DeserializeObject<Dictionary<string, MsCompanyModel>>(apiResult);
            //                 var company = data["payload"];
            //		_Company = company;
            //             }
            //}

            //co.Id = _Company.id.ToString();
            //co.Address = _Company.address;
            //co.Name = _Company.name;
            //co.Phone = _Company.phone;

            //return co;

            List<Company> listCompany = await getAllCompany();
            Company co = listCompany.Where(company => company.Id == Id).FirstOrDefault();
            return co;
        }

        [HttpPost]
        public static async Task<String> addCompany(CompanyAddModel model)
        {
            string result = "";

            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7082/api/Company", content))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject(apiResult).ToString();
                }
            }
            return result;
        }

        [HttpDelete]
        public static async Task<String> deleteCompany(String id)
        {
            string result = "";
            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                using (var response = await client.DeleteAsync("https://localhost:7082/api/Company/" + id))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject(apiResult).ToString();
                }
            }
            return result;
        }

        [HttpPatch]
        public static async Task<String> editCompany(CompanyEditModel model)
        {
			string result = "";
			using (var handler = connect())
			using (var client = new HttpClient(handler))
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
				using (var response = await client.PatchAsync("https://localhost:7082/api/Company", content))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					result = JsonConvert.DeserializeObject(apiResult).ToString();
				}
			}
			return result;
		}
	}
}

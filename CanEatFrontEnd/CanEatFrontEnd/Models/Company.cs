using CanEatFrontEnd.Models.DBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

		private static HttpClientHandler _clientHandler = new HttpClientHandler();

		private static void connect()
		{
			_clientHandler.ServerCertificateCustomValidationCallback = (sender, cert
				, chain, SslPolicyErrors) => { return true; };
		}


		[HttpGet]
		public static async Task<List<Company>> getAllCompany()
		{
			List<MsCompanyModel> _CompanyList = new List<MsCompanyModel>();
			List<Company> companyList = new List<Company>();

			connect();
			using (var client = new HttpClient(_clientHandler))
			{
				using (var response = await client.GetAsync("https://localhost:7082/api/Company"))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					_CompanyList = JsonConvert.DeserializeObject<List<MsCompanyModel>>(apiResult);
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
			MsCompanyModel _Company = new MsCompanyModel();
			Company co = new Company();

			connect();
			using (var client = new HttpClient(_clientHandler))
			{
				using (var response = await client.GetAsync("https://localhost:7082/api/Company/" + Id))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
					_Company = JsonConvert.DeserializeObject<MsCompanyModel>(apiResult);
				}
			}
			
			co.Id = _Company.id.ToString();
			co.Address = _Company.address;
			co.Name = _Company.name;
			co.Phone = _Company.phone;
			
			return co;
		}
	}
}

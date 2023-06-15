using CanEatFrontEnd.Models.DBModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace CanEatFrontEnd.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Company Company { get; set; }
        public List<Cart> cartList { get; set; }

        public Customer()
        {
            Company = new Company();
            cartList = new List<Cart>();
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
		public static async Task<List<Customer>> getAllCustomer()
		{
			List<MsCustomerModel> _CustomerList = new List<MsCustomerModel>();
			List<Customer> customerList = new List<Customer>();

            using (var handler = connect())
            using (var client = new HttpClient(handler))
			{
				using (var response = await client.GetAsync("https://localhost:7082/api/Customer"))
				{
					string apiResult = await response.Content.ReadAsStringAsync();
                    //_CustomerList = JsonConvert.DeserializeObject<JsonArray>(apiResult);
                    var data = JsonConvert.DeserializeObject<Dictionary<string, List<MsCustomerModel>>>(apiResult);
                    var users = data["payload"];
                    foreach (var i in users)
					{
						_CustomerList.Add(i);
					}

                }
			}
			foreach (MsCustomerModel c in _CustomerList)
			{
				Customer cus = new Customer();
				cus.Id = c.id.ToString();
				cus.Name = c.name;
				cus.Email = c.email;
				cus.Phone = c.phone;
				cus.Password = c.password;
				cus.Company = await Company.getCompany(c.company_id.ToString());
				customerList.Add(cus);
			}
			return customerList;
		}

		[HttpGet]
		public static async Task<Customer> getCustomer(string id)
		{
			//MsCustomerModel _Customer = new MsCustomerModel();
			//Customer cus = new Customer();

			//         using (var handler = connect())
			//         using (var client = new HttpClient(handler))
			//{
			//	using (var response = await client.GetAsync("https://localhost:7082/api/Customer/" + id))
			//	{
			//		string apiResult = await response.Content.ReadAsStringAsync();
			//		_Customer = JsonConvert.DeserializeObject<MsCustomerModel>(apiResult);
			//	}
			//}
			//cus.Id = _Customer.id.ToString();
			//cus.Name = _Customer.name;
			//cus.Email = _Customer.email;
			//cus.Phone = _Customer.phone;
			//cus.Password = _Customer.password;
			//         cus.Company = await Company.getCompany(_Customer.company_id.ToString());
			List<Customer> listCustomer = await getAllCustomer();
			Customer cus = listCustomer.Where(customer => customer.Id == id).FirstOrDefault();
			return cus;
		}

		[HttpGet]
		public static async Task<String> login(string email, string pass)
		{
			String id = "";
            using (var handler = connect())
            using (var client = new HttpClient(handler))
            {
                using (var response = await client.GetAsync("https://localhost:7082/api/Customer/"+email + ", " + pass))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    //_CustomerList = JsonConvert.DeserializeObject<JsonArray>(apiResult);
                    var data = JsonConvert.DeserializeObject<Dictionary<string, MsCustomerModel>>(apiResult);
                    var user = data["payload3"];
					if(user != null)
					{
						id = user.id.ToString();
					}
					else
					{
						id = null;
					}
					
                }
            }
			return id;
        }

		[HttpPatch]
		public static async Task<String> editCustomer()
		{

			return "";
		}

		[HttpDelete]
		public static async Task<String> deleteCustomer(string id)
		{
			return "";
		}
	}
}

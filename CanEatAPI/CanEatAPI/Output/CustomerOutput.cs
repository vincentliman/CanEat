using System.Drawing;
using System.Reflection;

namespace CanEatAPI.Output
{
    public class CustomerOutput
    {
        public List<Customer> payload { get; set; }
        public CustomerOutput()
        {
            payload = new List<Customer>();
        }

    }

    public class Customer
    {
        public string id { get; set; }
        public string company_id { get; set; }
        //public string company_name { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
    }


}

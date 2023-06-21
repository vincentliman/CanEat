using System.Drawing;
using System.Reflection;

namespace CanEatAPI.Output
{
    public class ShopOutput
    {
        public List<Shop> payload { get; set; }
        public ShopOutput()
        {
            payload = new List<Shop>();
        }
    }

    public class Shop
    {
        public string id { get; set; }
        public string company_id { get; set; }
        //public string company_name { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public Boolean status { get; set; }

    }

}

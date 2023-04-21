using System.ComponentModel.DataAnnotations;

namespace CanEatAPI.Models
{
    public class MsCustomer
    {
        [Key]
        public string id { get; set; }
        public string company_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set;}

    }
}

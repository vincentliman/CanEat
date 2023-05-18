using System.ComponentModel.DataAnnotations;

namespace CanEatAPI.Models
{
    public class MsCustomer
    {
        [Key]
        public Guid id { get; set; }
        public Guid company_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set;}

    }
}

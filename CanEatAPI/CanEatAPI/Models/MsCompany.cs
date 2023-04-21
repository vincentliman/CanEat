using System.ComponentModel.DataAnnotations;

namespace CanEatAPI.Models
{
    public class MsCompany
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

    }
}

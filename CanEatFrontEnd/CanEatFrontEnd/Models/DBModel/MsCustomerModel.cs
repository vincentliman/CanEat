using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CanEatFrontEnd.Models.DBModel
{
    [JsonObject]
    public class MsCustomerModel
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

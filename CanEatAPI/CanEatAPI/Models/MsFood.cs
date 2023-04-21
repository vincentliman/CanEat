using System.ComponentModel.DataAnnotations;

namespace CanEatAPI.Models
{
    public class MsFood
    {
        [Key]
        public string id { get; set; }
        public string shop_id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string photo { get; set; }
        
    }
}

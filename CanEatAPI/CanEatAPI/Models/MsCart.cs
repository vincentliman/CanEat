using System.ComponentModel.DataAnnotations;

namespace CanEatAPI.Models
{
    public class MsCart
    {
        [Key]
        public string id { get; set; }
        
        public string customer_id { get; set; }
        public string food_id { get; set; }
        public int quantity { get; set; }
        public string notes { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace CanEatFrontEnd.Models.DBModel
{
    public class MsCartModel
    {
        [Key]
        public string id { get; set; }
        
        public string customer_id { get; set; }
        public string food_id { get; set; }
        public int quantity { get; set; }
        public string notes { get; set; }

    }
}

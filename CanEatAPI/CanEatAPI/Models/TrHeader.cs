using System.ComponentModel.DataAnnotations;

namespace CanEatAPI.Models
{
    public class TrHeader
    {
        [Key]
        public string id { get; set; }
        public string shop_id { get; set; }

        public string customer_id { get; set; }

        public DateTime date { get; set; }
        public DateTime pickUpDateTime { get; set; }
        public bool paymentStatus { get; set; }
        public bool pickUpStatus { get; set; }


    }
}

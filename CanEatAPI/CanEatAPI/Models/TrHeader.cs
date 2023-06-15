using System.ComponentModel.DataAnnotations;

namespace CanEatAPI.Models
{
    public class TrHeader
    {
        [Key]
        public Guid tr_id { get; set; }
        public Guid shop_id { get; set; }
        public Guid customer_id { get; set; }
        public DateTime date { get; set; }
        public DateTime pickUpDateTime { get; set; }
        public bool paymentStatus { get; set; }
        public bool pickUpStatus { get; set; }


    }
}

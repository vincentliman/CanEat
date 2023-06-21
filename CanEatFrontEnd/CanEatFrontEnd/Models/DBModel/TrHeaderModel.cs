using System.ComponentModel.DataAnnotations;

namespace CanEatFrontEnd.Models.DBModel
{
    public class TrHeaderModel
    {
        [Key]
        public string tr_id { get; set; }
        public string shop_id { get; set; }

        public string customer_id { get; set; }

        public DateTime date { get; set; }
        public DateTime pickUpDateTime { get; set; }
        public bool paymentStatus { get; set; }
        public bool pickUpStatus { get; set; }


    }
}

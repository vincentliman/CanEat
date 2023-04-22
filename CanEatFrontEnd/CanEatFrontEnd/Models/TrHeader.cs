using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CanEatFrontEnd.Models
{
    public class TrHeader
    {
        public string ID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public DateTime PickupDateTime { get; set; }
        public Boolean PaymentStatus { get; set; }
        public Boolean PickupStatus { get; set; }
        public string ShopID { get; set; }
        public string CustomerID { get; set; }
    }
}

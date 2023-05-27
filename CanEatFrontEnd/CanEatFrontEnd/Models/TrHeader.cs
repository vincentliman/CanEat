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
        public Vendor Vendor { get; set; }
        public Customer Customer { get; set; }

        public List<TrDetail> detailList { get; set; }

        public TrHeader()
        {
            Vendor = new Vendor();
            Customer = new Customer();
            detailList = new List<TrDetail>();
        }
    }
}

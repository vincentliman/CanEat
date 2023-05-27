using System.Diagnostics;

namespace CanEatFrontEnd.Models.PageModel.VendorHomeModel
{
    public class VendorHomeModel
    {
        public List<TrHeader> trList {  get; set; }
        public Vendor? vendorInfo { get; set; }

        public DateTime latestDate { get; set; }

        public VendorHomeModel() { 
            trList = new List<TrHeader>();
            vendorInfo = new Vendor();
        }
    }
}

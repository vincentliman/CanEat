using System.Diagnostics;

namespace CanEatFrontEnd.Models.PageModel.VendorHomeModel
{
    public class VendorHomeModel
    {
        public List<TransactionInfo> trList {  get; set; }
        public Vendor? vendorInfo { get; set; }
        
        public VendorHomeModel() { 
            trList = new List<TransactionInfo>();
            vendorInfo = new Vendor();
        }
    }
}

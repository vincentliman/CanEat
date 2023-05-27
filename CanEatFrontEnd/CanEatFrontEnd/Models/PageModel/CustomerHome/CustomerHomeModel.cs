namespace CanEatFrontEnd.Models.PageModel.CustomerHome
{
    public class CustomerHomeModel
    {
        public List<Vendor>? vendorList {  get; set; }
        public TrHeader? latestTrans { get; set; }

        public CustomerHomeModel() { 
            vendorList = new List<Vendor>();
            latestTrans = new TrHeader();
        }

    }
}

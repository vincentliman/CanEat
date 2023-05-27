namespace CanEatFrontEnd.Models.PageModel.VendorShopInfo
{
    public class VendorShopInfoModel
    {
        public Vendor currVendor { get; set; }
        public List<Food> foodList {  get; set; }

        public VendorShopInfoModel() {
            currVendor = new Vendor();
            foodList = new List<Food>();
        }

    }
}

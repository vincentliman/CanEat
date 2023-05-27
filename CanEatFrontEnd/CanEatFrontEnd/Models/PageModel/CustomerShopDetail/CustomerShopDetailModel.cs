namespace CanEatFrontEnd.Models.PageModel.CustomerShopDetail
{
    public class CustomerShopDetailModel
    {
        public Vendor currVendor { get; set; }
        public List<Food> foodList { get; set; }

        public CustomerShopDetailModel()
        {
            currVendor = new Vendor();
            foodList = new List<Food>();
        }
    }
}

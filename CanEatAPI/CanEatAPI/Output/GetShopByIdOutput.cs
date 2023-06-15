namespace CanEatAPI.Output
{
    public class GetShopByIdOutput
    {
        public ShopDataById? payload { get; set; }
        public GetShopByIdOutput()
        {
            payload = new ShopDataById();
        }
    }

    public class ShopDataById
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool status { get; set; }
    }
}

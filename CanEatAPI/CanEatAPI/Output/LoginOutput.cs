namespace CanEatAPI.Output
{
    public class LoginOutput
    {
        public ShopData payload2 { get; set; }
        public LoginOutput()
        {
            payload2 = new ShopData();
        }
    }

    public class ShopData
    {
        public string id { get; set; }
        public string company_id { get; set; }
        public string name { get; set; }

    }



}

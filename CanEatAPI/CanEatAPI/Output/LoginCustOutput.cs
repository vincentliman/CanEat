namespace CanEatAPI.Output
{
    public class LoginCustOutput
    {
        public CustomerData payload3 { get; set; }
        public LoginCustOutput()
        {
            payload3 = new CustomerData();
        }
    }

    public class CustomerData
    {
        public string id { get; set; }
        public string company_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

    }
}

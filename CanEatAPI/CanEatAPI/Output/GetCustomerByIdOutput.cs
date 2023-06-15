namespace CanEatAPI.Output
{
    public class GetCustomerByIdOutput
    {
        public CustomerDataById? payload { get; set; }
        public GetCustomerByIdOutput()
        {
            payload = new CustomerDataById();
        }
    }

    public class CustomerDataById
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }


}

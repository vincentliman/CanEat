namespace CanEatAPI.Input
{
    public class CreateTrHeaderInput
    {

        public string? shop_name { get; set; }
        public string? customer_name { get; set; }
        //public DateTime date { get; set; }
        public DateTime pickUpDateTime { get; set; }
    }
}

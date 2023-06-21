namespace CanEatAPI.Input
{
    public class CreateTrHeaderInput
    {

        public string? shop_id { get; set; }
        public string? customer_id { get; set; }
        //public DateTime date { get; set; }
        public DateTime pickUpDateTime { get; set; }
    }
}

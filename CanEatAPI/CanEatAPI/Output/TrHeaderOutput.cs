namespace CanEatAPI.Output
{
    public class TrHeaderOutput
    {
        public List<TrHead> payload { get; set; }
        public TrHeaderOutput()
        {
            payload = new List<TrHead>();
        }
    }


    public class TrHead
    {
        public string tr_id { get; set; }
        public string shop_id { get; set; }

        public string customer_id { get; set; }
        public DateTime date { get; set; }
        public DateTime pickUpDateTime { get; set; }
        public bool paymentStatus { get; set; }
        public bool pickUpStatus { get; set; }
    }
}

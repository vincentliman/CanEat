namespace CanEatAPI.Output
{
    public class CartOutput
    {
        public List<CartOut> payload { get; set; }
        public CartOutput()
        {
            payload = new List<CartOut>();
        }
    }

    public class CartOut
    {
        public string customer_id { get; set; }
        public string food_id { get; set; }
        public int qty { get; set; }
        public string notes { get; set; }
    }
}

namespace CanEatFrontEnd.Models.OtherDBModel
{
    public class CartDeleteItemModel
    {
        public string customer_id { get; set; }
        public string food_id { get; set; }
        public int qty { get; set; }
        public string notes { get; set; }
    }
}

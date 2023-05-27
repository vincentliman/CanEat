namespace CanEatFrontEnd.Models
{
    public class Cart
    {
        public Food Food { get; set; }
        public int Qty { get; set; }
        public string Notes { get; set; }
        
        public Cart() {
            Food = new Food();
        }
    }
}

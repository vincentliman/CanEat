namespace CanEatFrontEnd.Models
{
    public class TrDetail
    {
        public Food Food { get; set; }
        public int Qty { get; set; }
        public string Notes { get; set; }

        public TrDetail() {
            Food = new Food();
        }
    }
}

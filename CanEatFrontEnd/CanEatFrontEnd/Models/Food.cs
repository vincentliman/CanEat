namespace CanEatFrontEnd.Models
{
    public class Food
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public decimal Rating { get; set; }
        public Vendor Vendor { get; set; }

        public Food()
        {
            Vendor = new Vendor();
        }
    }
}

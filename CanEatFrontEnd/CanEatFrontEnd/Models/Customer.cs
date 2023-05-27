namespace CanEatFrontEnd.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Company Company { get; set; }
        public List<Cart> cartList { get; set; }

        public Customer()
        {
            Company = new Company();
            cartList = new List<Cart>();
        }
    }
}

namespace CanEatFrontEnd.Models.PageModel.CustomerCart
{
    public class CustomerCartModel
    {
        public Customer currCustomer { get; set; }
        public List<Cart> carts { get; set; }

        public CustomerCartModel() {
            currCustomer = new Customer();
            carts = new List<Cart>();
            
        }
    }
}

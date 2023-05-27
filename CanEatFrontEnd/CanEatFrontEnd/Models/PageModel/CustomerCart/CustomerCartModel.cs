namespace CanEatFrontEnd.Models.PageModel.CustomerCart
{
    public class CustomerCartModel
    {
        public Customer currCustomer { get; set; }

        public CustomerCartModel() {
            currCustomer = new Customer();
            
        }
    }
}

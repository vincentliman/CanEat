namespace CanEatFrontEnd.Models.PageModel.AdminHome
{
    public class AdminHomeModel
    {
        public List<Vendor> verifyList { get; set; }
        public List<Vendor> vendorList { get; set; }
        public List<Customer> customerList { get; set; }
        public List<Company> companyList { get; set; }

        public AdminHomeModel() {
            verifyList = new List<Vendor>();
            vendorList = new List<Vendor>();
            customerList = new List<Customer>();
            companyList = new List<Company>();
        }
    }
}

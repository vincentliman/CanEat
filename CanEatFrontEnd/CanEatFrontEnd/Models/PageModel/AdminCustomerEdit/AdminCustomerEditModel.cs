namespace CanEatFrontEnd.Models.PageModel.AdminCustomerEdit
{
	public class AdminCustomerEditModel
	{
		public Customer currCustomer { get; set; }
		public List<Company> companyList { get; set; }

		public AdminCustomerEditModel() {
			currCustomer = new Customer();
			companyList = new List<Company>();
		}
	}
}

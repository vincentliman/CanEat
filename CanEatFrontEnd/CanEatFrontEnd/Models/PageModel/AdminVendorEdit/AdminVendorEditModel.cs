namespace CanEatFrontEnd.Models.PageModel.AdminVendorEdit
{
	public class AdminVendorEditModel
	{
		public Vendor currVendor { get; set; }
		public List<Company> companyList { get; set; }

		public AdminVendorEditModel()
		{
			currVendor = new Vendor();
			companyList = new List<Company>();
		}
	}
}

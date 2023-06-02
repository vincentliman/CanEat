namespace CanEatFrontEnd.Models.PageModel.AdminCompanyEdit
{
	public class AdminCompanyEditModel
	{
		public Company currCompany { get; set; }

		public AdminCompanyEditModel() {
			currCompany = new Company();
		}
	}
}

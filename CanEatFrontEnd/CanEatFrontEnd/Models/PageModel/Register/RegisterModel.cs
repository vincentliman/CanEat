namespace CanEatFrontEnd.Models.PageModel.Register
{
	public class RegisterModel
	{
		public List<Company> companyList { get; set; }

		public RegisterModel() { 
			companyList = new List<Company>();
		}
	}
}

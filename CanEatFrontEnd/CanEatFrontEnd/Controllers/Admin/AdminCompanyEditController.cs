using CanEatFrontEnd.Models.PageModel.AdminCompanyEdit;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
	public class AdminCompanyEditController : Controller
	{
		public IActionResult Index()
		{
			AdminCompanyEditModel model = new AdminCompanyEditModel();
			Models.Company co1 = new Models.Company();
			model.currCompany = co1;

			co1.ID = "abc-452";
			co1.Name = "Bina Nusantara University";
			co1.Address = "Jl. Alam Sutera 12 Tangerang";
			co1.Phone = "345678919201";

			return View("Views/Admin/CompanyEdit/Index.cshtml", model);
		}
	}
}

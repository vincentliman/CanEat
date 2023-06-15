using CanEatFrontEnd.Models.DBModel;
using CanEatFrontEnd.Models.OtherDBModel;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
	public class AdminCompanyAddController : Controller
	{
		public IActionResult Index()
		{
			return View("Views/Admin/CompanyAdd/Index.cshtml");
		}

		public async Task<IActionResult> AddCompany()
		{

			CompanyAddModel model = new CompanyAddModel();
			model.name = Request.Form["name"];
			model.address = Request.Form["address"];
			model.phone = Request.Form["phone"];

			await Models.Company.addCompany(model);
            return RedirectToAction("Index", "AdminHome");
		}
	}
}

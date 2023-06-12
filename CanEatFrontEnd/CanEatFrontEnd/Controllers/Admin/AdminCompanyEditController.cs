using CanEatFrontEnd.Models.PageModel.AdminCompanyEdit;
using CanEatFrontEnd.Models.OtherDBModel;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
	public class AdminCompanyEditController : Controller
	{
		public async Task<IActionResult> Index(String id)
		{
			AdminCompanyEditModel model = new AdminCompanyEditModel();
			
			model.currCompany = await Models.Company.getCompany(id);

   //         Models.Company co1 = new Models.Company();
   //         co1.Id = "abc-452";
			//co1.Name = "Bina Nusantara University";
			//co1.Address = "Jl. Alam Sutera 12 Tangerang";
			//co1.Phone = "345678919201";

			return View("Views/Admin/CompanyEdit/Index.cshtml", model);
		}

		public async Task<IActionResult> editCompany()
		{
			CompanyEditModel model = new CompanyEditModel();
			model.id = Request.Form["id"];
			model.name = Request.Form["name"];
			model.address = Request.Form["address"];
			model.phone = Request.Form["phone"];

			await Models.Company.editCompany(model);
			return RedirectToAction("Index", "AdminHome");
		}
	}
}

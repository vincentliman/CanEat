using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
	public class AdminCompanyEditController : Controller
	{
		public IActionResult Index()
		{
			return View("Views/Admin/CompanyEdit/Index.cshtml");
		}
	}
}

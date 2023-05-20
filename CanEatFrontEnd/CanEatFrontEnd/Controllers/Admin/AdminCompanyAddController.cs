using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
	public class AdminCompanyAddController : Controller
	{
		public IActionResult Index()
		{
			return View("Views/Admin/CompanyAdd/Index.cshtml");
		}
	}
}

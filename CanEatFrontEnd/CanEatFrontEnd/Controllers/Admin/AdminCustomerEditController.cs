using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
	public class AdminCustomerEditController : Controller
	{
		public IActionResult Index()
		{
			return View("Views/Admin/CustomerEdit/Index.cshtml");
		}
	}
}

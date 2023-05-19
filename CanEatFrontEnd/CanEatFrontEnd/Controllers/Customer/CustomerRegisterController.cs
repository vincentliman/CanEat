using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
	public class CustomerRegisterController : Controller
	{
		public IActionResult Index()
		{
			return View("Views/Customer/Register/Index.cshtml");
		}
	}
}

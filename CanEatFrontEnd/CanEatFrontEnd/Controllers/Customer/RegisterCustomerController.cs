using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
	public class RegisterCustomerController : Controller
	{
		public IActionResult Index()
		{
			return View("Views/Customer/Register/Index.cshtml");
		}
	}
}

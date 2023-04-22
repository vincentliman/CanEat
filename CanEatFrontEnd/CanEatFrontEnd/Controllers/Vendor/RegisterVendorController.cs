using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
	public class RegisterVendorController : Controller
	{
		public IActionResult Index()
		{
			return View("Views/Vendor/Register/Index.cshtml");
		}
	}
}

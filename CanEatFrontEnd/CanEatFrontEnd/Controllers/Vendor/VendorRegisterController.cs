using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
	public class VendorRegisterController : Controller
	{
		public IActionResult Index()
		{
			return View("Views/Vendor/Register/Index.cshtml");
		}
	}
}

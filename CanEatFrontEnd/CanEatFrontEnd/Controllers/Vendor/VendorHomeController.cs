using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorHomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Vendor/Home/Index.cshtml");
        }
    }
}

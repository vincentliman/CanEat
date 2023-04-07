using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Vendor/Home/Index.cshtml");
        }
    }
}

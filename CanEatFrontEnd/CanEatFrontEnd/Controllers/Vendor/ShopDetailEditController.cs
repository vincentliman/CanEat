using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class ShopDetailEditController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Vendor/ShopDetailEdit/Index.cshtml");
        }
    }
}

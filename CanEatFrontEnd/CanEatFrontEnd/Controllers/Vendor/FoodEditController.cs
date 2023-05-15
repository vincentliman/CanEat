using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class FoodEditController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Vendor/FoodEdit/Index.cshtml");
        }
    }
}

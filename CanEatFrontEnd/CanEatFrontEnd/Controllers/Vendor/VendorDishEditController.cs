using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorDishEditController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Vendor/DishEdit/Index.cshtml");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorDishInsertController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Vendor/DishInsert/Index.cshtml");
        }
    }
}

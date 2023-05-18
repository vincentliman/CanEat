using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class InsertFoodController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Vendor/InsertFood/Index.cshtml");
        }
    }
}

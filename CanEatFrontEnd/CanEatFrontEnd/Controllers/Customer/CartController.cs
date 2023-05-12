using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Customer/Cart/Index.cshtml");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CustomerCartController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Customer/Cart/Index.cshtml");
        }
    }
}

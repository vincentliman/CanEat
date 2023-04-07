using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Customer/Order/Index.cshtml");
        }
    }
}

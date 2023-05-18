using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class ReceiptController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Customer/Receipt/Index.cshtml");
        }
    }
}

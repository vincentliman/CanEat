using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CustomerReceiptController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Customer/Receipt/Index.cshtml");
        }
    }
}

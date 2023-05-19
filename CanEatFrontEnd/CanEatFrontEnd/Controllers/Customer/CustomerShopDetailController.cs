using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CustomerShopDetailController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Customer/ShopDetail/Index.cshtml");
        }
    }
}

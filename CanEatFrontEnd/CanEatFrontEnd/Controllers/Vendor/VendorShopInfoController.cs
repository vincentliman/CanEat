using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorShopInfoController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Vendor/ShopInfo/Index.cshtml");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
    public class AdminVendorEditController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Admin/VendorEdit/Index.cshtml");
        }
    }
}

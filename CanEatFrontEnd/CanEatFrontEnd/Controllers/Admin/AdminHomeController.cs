using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Admin/Home/Index.cshtml");
        }
    }
}

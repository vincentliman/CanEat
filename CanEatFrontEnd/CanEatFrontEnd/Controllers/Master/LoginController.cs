using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Master
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Master/Login/Index.cshtml");
        }

        [HttpPost]
        public IActionResult checkLogin()
        {
            return RedirectToAction("Index", "CustomerHome");
        }

        public IActionResult logout()
        {
            return View("Views/Master/LandingPage/Index.cshtml");
        }
    }
}

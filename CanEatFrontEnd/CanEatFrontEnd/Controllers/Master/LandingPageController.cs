using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Master
{
    public class LandingPageController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Master/LandingPage/Index.cshtml");
        }
    }
}

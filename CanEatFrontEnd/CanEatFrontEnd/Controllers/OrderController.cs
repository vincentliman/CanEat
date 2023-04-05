using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

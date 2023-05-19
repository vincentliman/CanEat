using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CustomerDishDetailController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Customer/DishDetail/Index.cshtml");
        }
    }
}

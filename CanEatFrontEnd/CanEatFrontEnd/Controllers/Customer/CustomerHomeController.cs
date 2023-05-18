using CanEatFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CustomerHomeController : Controller
    {
        private readonly ILogger<CustomerHomeController> _logger;

        public CustomerHomeController(ILogger<CustomerHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Views/Customer/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
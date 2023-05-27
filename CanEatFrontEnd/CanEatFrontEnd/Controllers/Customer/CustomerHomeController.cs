using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.CustomerHome;
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
            CustomerHomeModel model = new CustomerHomeModel();
            Models.TrHeader latestTr = new Models.TrHeader();
            Models.Vendor v1 = new Models.Vendor();
            Models.Vendor v2 = new Models.Vendor();
            model.vendorList.Add(v1);
            model.vendorList.Add(v2);
            model.latestTrans = latestTr;

            v1.Id = "abc-123";
            v1.Name = "Rocky Rooster";

            v2.Id = "def-456";
            v2.Name = "Fishy Chips";

            latestTr.Vendor.Name = "Rocky Rooster";
            
            return View("Views/Customer/Home/Index.cshtml", model);
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
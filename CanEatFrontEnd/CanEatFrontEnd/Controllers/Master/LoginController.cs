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
        public async Task<IActionResult> checkLogin()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            if(email.Equals("admin") && password.Equals("admin123")){
                return RedirectToAction("Index", "AdminHome");
            }
            string customerId = await Models.Customer.login(email, password);
            string vendorId = await Models.Vendor.login(email, password);
            if(customerId != null)
            {
                return RedirectToAction("Index", "CustomerHome", new { CustomerId = customerId });
            }else if(vendorId != null)
            {
                return RedirectToAction("Index", "VendorHome", new { VendorId = customerId });
            }
            else
            {
                TempData["error"] = "Invalid credential";
                return RedirectToAction("Index", "Login");
            }
            
        }

        public IActionResult logout()
        {
            return View("Views/Master/LandingPage/Index.cshtml");
        }
    }
}

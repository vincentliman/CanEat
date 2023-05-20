using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.VendorHomeModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorHomeController : Controller
    {
        public IActionResult Index()
        {
            TransactionInfo trans1 = new TransactionInfo();
            TrHeader t1 = new TrHeader();
            t1.ID = "asdas-asdasd-1212";
            t1.TransactionDateTime = DateTime.Now;
            trans1.header = t1;

            Models.Customer c1 = new Models.Customer();
            c1.Name = "Russ";
            trans1.customer = c1;
            
            Models.Vendor v1 = new Models.Vendor();
            v1.Name = "rocky";

            var model = new VendorHomeModel();
            model.trList.Add(trans1);
            model.vendorInfo = v1;
            
            return View("Views/Vendor/Home/Index.cshtml", model);
        }
    }
}

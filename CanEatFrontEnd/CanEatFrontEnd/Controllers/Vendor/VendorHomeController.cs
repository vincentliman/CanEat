using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.VendorHomeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Collections.Concurrent;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorHomeController : Controller
    {
        public IActionResult Index()
        {            
            TrHeader t1 = new TrHeader();
            t1.ID = "asdas-asdasd-1212";
            t1.TransactionDateTime = DateTime.Now;

            TrDetail d1 = new TrDetail();
            d1.Food.Name = "Paket A";
            d1.Food.Price = 25000;
            d1.Food.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 1 pcs Ayam Goreng Sayap + Nasi Putih";
            d1.Notes = "Ayamnya Dada aja ya";
            d1.Qty = 1;
            t1.detailList.Add(d1);

            TrDetail d2 = new TrDetail();
            d2.Food.Name = "Paket B";
            d2.Food.Price = 27000;
            d2.Food.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 2 pcs Ayam Goreng Sayap + Nasi Putih";
            d2.Notes = "Ayamnya paha atas sama sayap 2 aja ya";
            d2.Qty = 4;
            t1.detailList.Add(d2);

            TrHeader t2 = new TrHeader();
            t2.ID = "ghjghjghjg-asdasd-1345646";
            t2.TransactionDateTime = DateTime.Now.AddDays(1);
            t2.Customer.Name = "Juju";

            Models.Customer c1 = new Models.Customer();
            c1.Name = "Russ";
            t1.Customer = c1;

            Models.Vendor v1 = new Models.Vendor();
            v1.Name = "Rocky Rooster";
            v1.Id = "abc-123";

            var model = new VendorHomeModel();
            model.trList.Add(t1);
            model.trList.Add(t2);
            model.vendorInfo = v1;
            
            return View("Views/Vendor/Home/Index.cshtml", model);
        }
    }
}

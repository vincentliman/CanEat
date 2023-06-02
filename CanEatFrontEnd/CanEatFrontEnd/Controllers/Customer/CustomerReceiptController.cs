using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.CustomerReceipt;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CustomerReceiptController : Controller
    {
        public IActionResult Index()
        {
            CustomerReceiptModel model = new CustomerReceiptModel();
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

            Models.Customer c1 = new Models.Customer();
            c1.Name = "Russ";
            t1.Customer = c1;

            Models.Vendor v1 = new Models.Vendor();
            v1.Name = "Rocky Rooster";
            v1.Id = "abc-123";
            t1.Vendor = v1;

            model.currTrans = t1;
            
            return View("Views/Customer/Receipt/Index.cshtml", model);
        }
    }
}

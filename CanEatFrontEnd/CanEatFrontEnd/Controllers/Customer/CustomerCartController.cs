using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.CustomerCart;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CustomerCartController : Controller
    {
        public IActionResult Index()
        {
            CustomerCartModel model = new CustomerCartModel();
            Cart c1 = new Cart();
            Cart c2 = new Cart();
            Food f1 = new Food();
            Food f2 = new Food();
            Models.Customer cu = new Models.Customer();

            f1.Id = "abc-123";
            f1.Name = "Paket A";
            f1.Price = 25000;
            f1.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 1 pcs Ayam Goreng Sayap + Nasi Putih";

            f2.Id = "def-456";
            f2.Name = "Paket B";
            f2.Price = 27000;
            f2.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 2 pcs Ayam Goreng Sayap + Nasi Putih";

            c1.Qty = 1;
            c1.Food = f1;
            c1.Notes = "Ayamnya Dada aja ya";

            c2.Qty = 4;
            c2.Food = f2;
            c2.Notes = "Ayamnya paha atas sama sayap 2 aja ya";

            cu.Name = "Russ";
            cu.cartList.Add(c1);
            cu.cartList.Add(c2);

            model.currCustomer = cu;

            return View("Views/Customer/Cart/Index.cshtml", model);
        }
    }
}

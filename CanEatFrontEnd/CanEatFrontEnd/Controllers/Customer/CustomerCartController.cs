using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.OtherDBModel;
using CanEatFrontEnd.Models.PageModel.CustomerCart;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CustomerCartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            CustomerCartModel model = new CustomerCartModel();
            //Cart c1 = new Cart();
            //Cart c2 = new Cart();
            //Food f1 = new Food();
            //Food f2 = new Food();
            //Models.Customer cu = new Models.Customer();

            //f1.Id = "abc-123";
            //f1.Name = "Paket A";
            //f1.Price = 25000;
            //f1.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 1 pcs Ayam Goreng Sayap + Nasi Putih";

            //f2.Id = "def-456";
            //f2.Name = "Paket B";
            //f2.Price = 27000;
            //f2.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 2 pcs Ayam Goreng Sayap + Nasi Putih";

            //c1.Qty = 1;
            //c1.Food = f1;
            //c1.Notes = "Ayamnya Dada aja ya";

            //c2.Qty = 4;
            //c2.Food = f2;
            //c2.Notes = "Ayamnya paha atas sama sayap 2 aja ya";

            //cu.Name = "Russ";
            //cu.cartList.Add(c1);
            //cu.cartList.Add(c2);

            //model.currCustomer = cu;
            string id = HttpContext.Session.GetString("Id");
            model.currCustomer = await Models.Customer.getCustomer(id);
            model.carts = await Models.Cart.getCartCustomer(id);
            return View("Views/Customer/Cart/Index.cshtml", model);
        }

        public async Task<IActionResult> deleteItem(string foodId)
        {
            CartDeleteItemModel model = new CartDeleteItemModel();
            model.food_id = foodId;
            model.customer_id = HttpContext.Session.GetString("Id");
            model.qty = 0;
            model.notes = "-";
            await Cart.deleteCartItems(model);
            return RedirectToAction("Index", "CustomerCart");
        }

        public async Task<IActionResult> checkOut()
        {
            string date = Request.Form["pickup_date"];
            string time = Request.Form["pickup_time"];
            string dateString = date + "T" + time + ":00.000Z";
            HeaderAddModel model = new HeaderAddModel();
            model.pickUpDateTime = dateString;
            model.customer_id = HttpContext.Session.GetString("Id");
            List<Cart> foodList = await Cart.getCartCustomer(model.customer_id);
            Cart firstCart = new Cart();
            try
            {
                firstCart = foodList.FirstOrDefault();
            }
            catch
            {

            }
            string foodId = "";
            if (firstCart != null)
            {
                foodId = firstCart.Food.Vendor.Id;
            }
            model.shop_id = foodId;
            string trId = await TrHeader.addHeader(model);

            foreach(Cart c in foodList)
            {
                DetailAddModel d = new DetailAddModel();
                d.tr_id = trId;
                d.food_id = c.Food.Id;
                d.qty = c.Qty;
                d.notes = c.Notes;
                await TrDetail.addDetail(d);
            }
            await Cart.deleteAll(HttpContext.Session.GetString("Id"));
            return RedirectToAction("Index", "CustomerReceipt", new { transId = trId });
            //return RedirectToAction("Index", "CustomerHome");
        }
    }
}

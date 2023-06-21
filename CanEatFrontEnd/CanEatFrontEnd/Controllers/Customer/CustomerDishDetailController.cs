using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.OtherDBModel;
using CanEatFrontEnd.Models.PageModel.CustomerDishDetail;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Customer
{
    public class CustomerDishDetailController : Controller
    {
        public async Task<IActionResult> Index(string id)
        {
            CustomerDishDetailModel model = new CustomerDishDetailModel();
            //Food f1 = new Food();

            //f1.Id = "abc-123";
            //f1.Name = "Paket A";
            //f1.Price = 25000;
            //f1.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 1 pcs Ayam Goreng Sayap + Nasi Putih";

            model.currDish = await Models.Food.getFood(id);
            return View("Views/Customer/DishDetail/Index.cshtml", model);
        }

        public async Task<IActionResult> addToCart(string foodId)
        {
            CartAddModel model = new CartAddModel();
            model.food_id = foodId;
            string userId = HttpContext.Session.GetString("Id");
            model.customer_id = userId;
            model.qty = Convert.ToInt32(Request.Form["qty"]);
            model.notes = Request.Form["notes"];
            string result = await Cart.addToCart(model);
            return RedirectToAction("Index", "CustomerCart");
        }
    }
}

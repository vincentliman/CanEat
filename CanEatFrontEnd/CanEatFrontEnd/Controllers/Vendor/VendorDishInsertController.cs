using CanEatFrontEnd.Models.OtherDBModel;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorDishInsertController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Vendor/DishInsert/Index.cshtml");
        }

        public async Task<IActionResult> insertDish()
        {
            FoodAddModel model = new FoodAddModel();
            model.name = Request.Form["name"];
            model.description = Request.Form["desc"];
            model.price = Convert.ToInt32(Request.Form["price"]);
            model.shop_id = HttpContext.Session.GetString("Id");
            model.photo = "";
            string result = await Models.Food.addFood(model);
            return RedirectToAction("Index", "VendorShopInfo");
        }
    }
}

using CanEatFrontEnd.Models.OtherDBModel;
using CanEatFrontEnd.Models.PageModel.VendorDishEdit;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorDishEditController : Controller
    {
        public async Task<IActionResult> Index(string id)
        {
            VendorDishEditModel model = new VendorDishEditModel();
            //Models.Food f1 = new Models.Food();
             model.currFood = await Models.Food.getFood(id);
			
   //         f1.Id = "abc-123";
			//f1.Name = "Paket A";
			//f1.Price = 25000;
			//f1.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 1 pcs Ayam Goreng Sayap + Nasi Putih";

			return View("Views/Vendor/DishEdit/Index.cshtml", model);
        }

        public async Task<IActionResult> editDish()
        {
            FoodEditModel model = new FoodEditModel();
            model.id = Request.Form["id"];
			model.name = Request.Form["name"];
			model.description = Request.Form["desc"];
			model.price = Convert.ToInt32(Request.Form["price"]);
			model.shop_id = HttpContext.Session.GetString("Id");
			model.photo = "";
			string result = await Models.Food.editFood(model);
			return RedirectToAction("Index", "VendorShopInfo");
		}
    }
}

using CanEatFrontEnd.Models.PageModel.VendorDishEdit;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorDishEditController : Controller
    {
        public IActionResult Index()
        {
            VendorDishEditModel model = new VendorDishEditModel();
            Models.Food f1 = new Models.Food();
             model.currFood = f1;
			
            f1.Id = "abc-123";
			f1.Name = "Paket A";
			f1.Price = 25000;
			f1.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 1 pcs Ayam Goreng Sayap + Nasi Putih";

			return View("Views/Vendor/DishEdit/Index.cshtml", model);
        }
    }
}

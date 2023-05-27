using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.Register;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CanEatFrontEnd.Controllers.Customer
{
	public class CustomerRegisterController : Controller
	{
		public IActionResult Index()
		{
			RegisterModel model = new RegisterModel();
			Company c1 = new Company();
			c1.ID = "dasd3asd4a5s6da-23112312edsa";
			c1.Name = "Bina Nusantara University";
			Company c2 = new Company();
			c2.ID = "dasd3a-asda-s6da-23112312edsa";
			c2.Name = "Media Nusantara University";
			Company c3 = new Company();
			c1.ID = "aasd3a90-ps6da-23112312edsa";
			c1.Name = "Blabla";
			model.companyList.Add(c1);
			model.companyList.Add(c2);
			model.companyList.Add(c3);
			return View("Views/Customer/Register/Index.cshtml", model);
		}

		public IActionResult register()
		{
			return View("Views/Master/Login/Index.cshtml");
		}
	}
}

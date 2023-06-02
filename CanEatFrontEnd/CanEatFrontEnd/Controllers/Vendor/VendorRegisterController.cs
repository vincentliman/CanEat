using CanEatFrontEnd.Models.PageModel.Register;
using CanEatFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
	public class VendorRegisterController : Controller
	{
		public IActionResult Index()
		{
			RegisterModel model = new RegisterModel();
            Company co1 = new Company();
            Company co2 = new Company();
            Company co3 = new Company();

            model.companyList.Add(co1);
            model.companyList.Add(co2);
            model.companyList.Add(co3);

            co1.ID = "abc-452";
            co1.Name = "Bina Nusantara University";
            co1.Address = "Jl. Alam Sutera 12 Tangerang";
            co1.Phone = "345678919201";

            co2.ID = "dsf-123";
            co2.Name = "Media Nusantara University";
            co2.Address = "Jl. Gading Raya 22 Tangerang";
            co2.Phone = "123451234523";

            co3.ID = "iue-251";
            co3.Name = "PT Jaya Nusantara";
            co3.Address = "Jl. Lalala 120 Jakarta Pusat";
            co3.Phone = "890890890123";

            return View("Views/Vendor/Register/Index.cshtml", model);
		}

		public IActionResult register()
		{
			return View("Views/Master/Login/Index.cshtml");
		}
	}
}

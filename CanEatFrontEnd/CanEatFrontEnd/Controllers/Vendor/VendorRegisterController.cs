﻿using CanEatFrontEnd.Models.PageModel.Register;
using CanEatFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using CanEatFrontEnd.Models.OtherDBModel;

namespace CanEatFrontEnd.Controllers.Vendor
{
	public class VendorRegisterController : Controller
	{
		public async Task<IActionResult> Index()
		{
			RegisterModel model = new RegisterModel();
			//Company co1 = new Company();
			//Company co2 = new Company();
			//Company co3 = new Company();

			//model.companyList.Add(co1);
			//model.companyList.Add(co2);
			//model.companyList.Add(co3);

			//co1.Id = "abc-452";
			//co1.Name = "Bina Nusantara University";
			//co1.Address = "Jl. Alam Sutera 12 Tangerang";
			//co1.Phone = "345678919201";

			//co2.Id = "dsf-123";
			//co2.Name = "Media Nusantara University";
			//co2.Address = "Jl. Gading Raya 22 Tangerang";
			//co2.Phone = "123451234523";

			//co3.Id = "iue-251";
			//co3.Name = "PT Jaya Nusantara";
			//co3.Address = "Jl. Lalala 120 Jakarta Pusat";
			//co3.Phone = "890890890123";
			model.companyList = await Models.Company.getAllCompany();

			return View("Views/Vendor/Register/Index.cshtml", model);
		}

		public async Task<IActionResult> register()
		{
			VendorRegisterModel model = new VendorRegisterModel();
			model.name = Request.Form["name"];
            model.email = Request.Form["email"];
			model.phone = Request.Form["number"];
			model.password = Request.Form["psw"];
			model.company_name = Request.Form["company"];
			await Models.Vendor.vendorRegister(model);
            return View("Views/Master/Login/Index.cshtml");
		}
	}
}

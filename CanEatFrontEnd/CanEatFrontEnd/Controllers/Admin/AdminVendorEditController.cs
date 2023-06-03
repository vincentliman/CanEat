using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.AdminVendorEdit;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
    public class AdminVendorEditController : Controller
    {
        public IActionResult Index()
        {
            AdminVendorEditModel model = new AdminVendorEditModel();
			Company co1 = new Company();
			Company co2 = new Company();
			Company co3 = new Company();
			Models.Vendor v1 = new Models.Vendor();

			model.companyList.Add(co1);
			model.companyList.Add(co2);
			model.companyList.Add(co3);
			model.currVendor = v1;

            co1.Id = "abc-452";
            co1.Name = "Bina Nusantara University";
            co1.Address = "Jl. Alam Sutera 12 Tangerang";
            co1.Phone = "345678919201";

            co2.Id = "dsf-123";
            co2.Name = "Media Nusantara University";
            co2.Address = "Jl. Gading Raya 22 Tangerang";
            co2.Phone = "123451234523";

            co3.Id = "iue-251";
            co3.Name = "PT Jaya Nusantara";
            co3.Address = "Jl. Lalala 120 Jakarta Pusat";
            co3.Phone = "890890890123";

            v1.Id = "abc-123";
			v1.Name = "Rocky Rooster";
			v1.Email = "rocky.rooster@rocky.com";
			v1.Company = co1;
			v1.Password = "rocky1";
			v1.Phone = "123456789012";
			v1.Status = true;
			return View("Views/Admin/VendorEdit/Index.cshtml", model);
        }
    }
}

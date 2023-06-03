using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.AdminCustomerEdit;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Admin
{
	public class AdminCustomerEditController : Controller
	{
		public IActionResult Index()
		{
			AdminCustomerEditModel model = new AdminCustomerEditModel();
			Company co1 = new Company();
			Company co2 = new Company();
			Company co3 = new Company();
			Models.Customer cu1 = new Models.Customer();

			model.companyList.Add(co1);
			model.companyList.Add(co2);
			model.companyList.Add(co3);
			model.currCustomer = cu1;

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

            cu1.Id = "cbc-123";
			cu1.Name = "Russ";
			cu1.Email = "RussRuss@mailme.com";
			cu1.Phone = "124312347098";
			cu1.Password = "RRR123";
			cu1.Company = co1;

			return View("Views/Admin/CustomerEdit/Index.cshtml", model);
		}
	}
}

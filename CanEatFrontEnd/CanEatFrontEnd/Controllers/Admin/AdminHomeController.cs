using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.AdminHome;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Security;
using Newtonsoft.Json;

namespace CanEatFrontEnd.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            AdminHomeModel model = new AdminHomeModel();
            Models.Vendor v1 = new Models.Vendor();
            Models.Vendor v2 = new Models.Vendor();
            Models.Vendor v3 = new Models.Vendor();
            Models.Vendor v4 = new Models.Vendor();
            Models.Company co1 = new Models.Company();
            Models.Company co2 = new Models.Company();
            Models.Company co3 = new Models.Company();
            Models.Customer cu1 = new Models.Customer();
            Models.Customer cu2 = new Models.Customer();
            Models.Customer cu3 = new Models.Customer();
            
            model.verifyList.Add(v2);
            model.verifyList.Add(v4);
            
            model.vendorList.Add(v1);
            model.vendorList.Add(v2);
            model.vendorList.Add(v3);
            model.vendorList.Add(v4);

            model.companyList.Add(co1);
            model.companyList.Add(co2);
            model.companyList.Add(co3);

            model.customerList.Add(cu1);
            model.customerList.Add(cu2);
            model.customerList.Add(cu3);

            v1.Id = "abc-123";
            v1.Name = "Rocky Rooster";
            v1.Email = "rocky.rooster@rocky.com";
            v1.Company = co1;
            v1.Password = "rocky1";
            v1.Phone = "123456789012";
            v1.Status = true;

            v2.Id = "ghi-789";
            v2.Name = "Warung Mangan";
            v2.Email = "War@mangan.com";
            v2.Company = co2;
            v2.Password = "abc123";
            v2.Phone = "098765432134";
            v2.Status = false;

            v3.Id = "def-456";
            v3.Name = "Fishy Chips";
            v3.Email = "Fishy@chips.co.id";
            v3.Company = co1;
            v3.Password = "fish2";
            v3.Phone = "678901234556";
            v3.Status = true;

            v4.Id = "jkl-637";
            v4.Name = "Rotiku";
            v4.Email = "nyam.roti@mail.com";
            v4.Company = co1;
            v4.Password = "rotiroti";
            v4.Phone = "102938475635";
            v4.Status = false;

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

            cu2.Id = "fhx-243";
            cu2.Name = "Juju";
            cu2.Email = "Juju@ondatbeat.com";
            cu2.Phone = "098745679876";
            cu2.Password = "JJ121";
            cu2.Company = co1;

            cu3.Id = "vnc-102";
            cu3.Name = "Mang Maman";
            cu3.Email = "ManLi@bibibi.mail";
            cu3.Phone = "081277772212";
            cu3.Password = "MangMaman1290";
            cu3.Company = co3;

            model.customerList = await Models.Customer.getAllCustomer();
            model.companyList = await Models.Company.getAllCompany();
            model.vendorList = await Models.Vendor.getAllVendor();
            model.verifyList = await Models.Vendor.getUnverified();


            return View("Views/Admin/Home/Index.cshtml", model);
        }

        public IActionResult deleteCompany()
        {
            return View();
        }

        public IActionResult deleteCustomer()
        {
            return View();
        }

        public IActionResult deleteVendor()
        {
            return View();
        }
        public IActionResult verifyVendor()
        {
            return View();
        }
    }
}

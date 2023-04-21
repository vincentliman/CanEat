using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CanEatAPI.Helper;
using CanEatAPI.Output;

namespace CanEatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public CompanyHelper companyHelper;
        public CompanyController(CompanyHelper companyHelper)
        {
            this.companyHelper = companyHelper;
        }

        [HttpGet]
        [Produces("application/json")]

        public IActionResult Get()
        {
            try
            {
                var objJSON = new CompanyOutput();
                objJSON.payload = companyHelper.GetAllCompanies();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

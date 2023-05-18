using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CanEatAPI.Helper;
using CanEatAPI.Output;
using CanEatAPI.Input;

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

        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post(CreateCompanyInput data)
        {
            try
            {
                var objJSON = companyHelper.CreateCompany(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public IActionResult Delete(string id)
        {
            try
            {
                var objJSON = companyHelper.DeleteCompany(id);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch]
        [Produces("application/json")]
        public IActionResult Patch(UpdateCompanyInput data)
        {
            try
            {
                var objJSON = companyHelper.UpdateCompany(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

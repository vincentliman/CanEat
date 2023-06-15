using CanEatAPI.Helper;
using CanEatAPI.Input;
using CanEatAPI.Output;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanEatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrHeaderController : ControllerBase
    {
        public TrHeaderHelper trheaderHelper;

        public TrHeaderController(TrHeaderHelper trheaderHelper)
        {
            this.trheaderHelper = trheaderHelper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                var objJSON = new TrHeaderOutput();
                objJSON.payload = trheaderHelper.GetAllTransactions();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Produces("application/json")]
        public IActionResult Patch(UpdateTrHeaderInput data)
        {
            try
            {
                var objJSON = trheaderHelper.UpdateTrHeader(data);
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
                var objJSON = trheaderHelper.DeleteTrHeader(id);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post(CreateTrHeaderInput data)
        {
            try
            {
                var objJSON = trheaderHelper.CreateTrHeader(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

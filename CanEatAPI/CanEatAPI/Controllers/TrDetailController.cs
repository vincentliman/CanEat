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
    public class TrDetailController : ControllerBase
    {
        public TrDetailHelper trdetailHelper;
        public TrDetailController(TrDetailHelper trdetailHelper)
        {
            this.trdetailHelper = trdetailHelper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                var objJSON = new TrDetailOutput();
                objJSON.payload = trdetailHelper.GetAllTrDetail();
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
                var objJSON = trdetailHelper.DeleteTrDetail(id);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Produces("application/json")]
        public IActionResult Patch(UpdateTrDetailInput data)
        {
            try
            {
                var objJSON = trdetailHelper.UpdateTrDetail(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post(CreateTrDetailInput data)
        {
            try
            {
                var objJSON = trdetailHelper.CreateTrDetail(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

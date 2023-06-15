using CanEatAPI.Helper;
using CanEatAPI.Input;
using CanEatAPI.Models;
using CanEatAPI.Output;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanEatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        public ShopHelper shopHelper;

        public ShopController(ShopHelper shopHelper)
        {
            this.shopHelper = shopHelper;
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post(CreateShopInput data)
        {
            try
            {
                var objJSON = shopHelper.CreateShop(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult Get(string id)
        {
            try
            {
                var objJSON = new GetShopByIdOutput();
                objJSON.payload = shopHelper.GetShopData(id);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Produces("application/json")]

        public IActionResult Get()
        {
            try
            {
                var objJSON = new ShopOutput();
                objJSON.payload = shopHelper.GetAllShops();
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
                var objJSON = shopHelper.DeleteShop(id);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Produces("application/json")]
        public IActionResult Patch(UpdateShopInput data)
        {
            try
            {
                var objJSON = shopHelper.UpdateShop(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{email}, {password}")]
        [Produces("application/json")]
        public IActionResult GetShop(string email, string password)
        {
            try
            {
                var objJSON = new LoginOutput();
                objJSON.payload2 = shopHelper.LoginShop(email, password);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

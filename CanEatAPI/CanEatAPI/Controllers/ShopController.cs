using CanEatAPI.Helper;
using CanEatAPI.Input;
using CanEatAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanEatAPI.Controllers
{
    [EnableCors]
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
        public IActionResult Post(ShopInput data)
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
    }
}

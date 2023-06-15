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
    public class FoodController : ControllerBase
    {
        public FoodHelper foodHelper;

        public FoodController(FoodHelper foodHelper)
        {
            this.foodHelper = foodHelper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                var objJSON = new FoodOutput();
                objJSON.payload = foodHelper.GetAllFoods();
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
                var objJSON = new GetFoodByIdOutput();
                objJSON.payload = foodHelper.GetFoodData(id);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post(CreateFoodInput data)
        {
            try
            {
                var objJSON = foodHelper.CreateFood(data);
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
                var objJSON = foodHelper.DeleteFood(id);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Produces("application/json")]
        public IActionResult Patch(UpdateFoodInput data)
        {
            try
            {
                var objJSON = foodHelper.UpdateFood(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpGet("{id}")]
        //[Produces("application/json")]
        //public IActionResult GetFood(string id)
        //{
        //    try
        //    {
        //        var objJSON = new FoodOutput2();
        //        objJSON.payload4 = foodHelper.GetFood(id);
        //        return new OkObjectResult(objJSON);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}

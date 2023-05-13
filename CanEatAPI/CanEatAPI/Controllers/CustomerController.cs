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
    public class CustomerController : ControllerBase
    {
        public CustomerHelper customerHelper;

        public CustomerController(CustomerHelper customerHelper)
        {
            this.customerHelper = customerHelper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                var objJSON = new CustomerOutput();
                objJSON.payload = customerHelper.GetAllCustomers();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post(CustomerInput data)
        {
            try
            {
                var objJSON = customerHelper.CreateCustomer(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{email}, {password}")]
        [Produces("application/json")]
        public IActionResult GetCustomer(string email, string password)
        {
            try
            {
                var objJSON = new LoginCustOutput();
                objJSON.payload3 = customerHelper.LoginCustomer(email, password);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}

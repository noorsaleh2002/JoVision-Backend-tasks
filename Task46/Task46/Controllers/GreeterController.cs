/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task46.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreeterController : ControllerBase
    {
    }
}*/


using Microsoft.AspNetCore.Mvc;
using Task46.Controllers.Models;

namespace Task46.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreeterController : ControllerBase
    {
        [HttpPost("Greeting")]
        public string Greet([FromForm] GreetingRequset requset)
        {

            string name = string.IsNullOrEmpty(requset.Name) ? "anonymous" : requset.Name;
            return $"Hello {name}";





        }



    }


}
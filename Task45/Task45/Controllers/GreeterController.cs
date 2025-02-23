
using Microsoft.AspNetCore.Mvc;

namespace Task45.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreeterControllers : ControllerBase
    {

        [HttpGet]
        public string GetGreeting([FromQuery] string name= "anonymous")
        {
            return $"Hello {name}";
        }


    }


}

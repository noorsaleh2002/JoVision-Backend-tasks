using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreeterController : ControllerBase
    {
        [HttpGet]
        public string GetGreeting([FromQuery] string name = "anonymous")
        {
            return $"Hello {name}";
        }

    }
}


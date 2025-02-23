using Microsoft.AspNetCore.Mvc;


namespace Task45.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthDateController : ControllerBase
    {
        [HttpGet]
        public string GetAge([FromQuery] string name = "anonymous", [FromQuery] int? years = null, [FromQuery] int? months = null, [FromQuery] int? days = null)
        {
            if (years == null || months == null || days == null)
            {
                return $"Hello {name}, I can’t calculate your age without knowing your birthdate!";
            }

            int age = DateTime.Now.Year - years.Value;

            return $"Hello {name}, your age is {age}";
        }
    }
}

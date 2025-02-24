using Microsoft.AspNetCore.Mvc;
using Task46.Controllers.Models;

namespace Task46.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BirthDateController : ControllerBase
    {

        [HttpPost("calculate-age")]
        public string BirthDate([FromForm] BirthDateRequest request)
        {
            string name = string.IsNullOrEmpty(request.Name) ? "anonymous" : request.Name;
            if(!request.Years.HasValue || !request.Months.HasValue || !request.Days.HasValue)
            {
                return $"Hello {name}, I can’t calculate your age without knowing your birthdate!";
            }
            DateTime dateTime = new DateTime((int)request.Years, (int)request.Months, (int)request.Days);
            int age = DateTime.Now.Year - dateTime.Year;

                if(DateTime.Now.DayOfYear<dateTime.DayOfYear)
            {
                age--;
            }
            return $"Hello {name}, your age is {age}";










        }



    }


}
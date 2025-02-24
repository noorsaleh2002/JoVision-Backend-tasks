using Microsoft.AspNetCore.Mvc;
using System;

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

         
            DateTime birthDate;
            try
            {
                birthDate = new DateTime(years.Value, months.Value, days.Value);
            }
            catch (Exception)
            {
                return $"Invalid birthdate provided!";
            }

           
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age))
            {
                age--;
            }

            return $"Hello {name}, your age is {age}";
        }
    }
}

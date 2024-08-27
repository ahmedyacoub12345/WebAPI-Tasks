using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        [Route("Calculator")]
        public IActionResult Calculator(string a)
        {
            var parts = a.Split(' ');

            var num1 = Convert.ToInt32(parts[0]);
            var operation = parts[1];
            var num2 = Convert.ToInt32(parts[2]);
            var result = 0;
            switch (operation)
            {
                case ("+"):
                    result = num1 + num2;
                    break;
                case ("-"):
                    result = num1 - num2;
                    break;
                case ("*"):
                    result = num1 * num2;
                    break;
                case ("/"):
                    if (num2 == 0)
                    {
                        return BadRequest("Division by zero is not allowed.");
                    }
                    result = num1 / num2;
                    break;
                default:
                    return BadRequest("Invalid operator. Use +, -, *, or /.");
            }

            return Ok(result);
        }

    }
}

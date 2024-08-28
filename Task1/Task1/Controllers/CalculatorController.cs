using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

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
        [HttpGet]
        [Route("Check number")]
        public IActionResult getNumber(int a, int b)
        {
            if (a == 30 ||b==30 ||a+b == 30)
            {
                return Ok("true");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("Check devide")]
        public IActionResult getResult(int a)
        {
            if (a % 3 == 0 || a % 7 == 0 && a >= 0)
            {
                return Ok("true");
            }
            else
            {
                return Ok("false");
            }
        }
    }
}

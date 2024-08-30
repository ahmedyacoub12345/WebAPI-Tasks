using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class LoggerController : ControllerBase
    {


        private readonly ILogger<LoggerController> _logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(Product))]
        public IActionResult GetData()
        {
            string[] ahmed = ["ahmed"];
            _logger.LogInformation($"Ahmed that excute to Log file {ahmed.Length}");
            return Ok(ahmed);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private EcommerceCoreContext _db;
        public OrdersController(EcommerceCoreContext db) 
        {
            _db = db;
        }
        [HttpGet]
        [Route("AllOrders/order")]
        public IActionResult Get()
        {
            var data = _db.Orders.ToList();
            return Ok(data);
        }
        [HttpGet]
        [Route("Order/{id}")]
        public IActionResult Get(int id)
        {
            var data = _db.Orders.Find(id);
            return Ok(data);
        }
        [HttpGet]
        [Route("OrderName")]
        public IActionResult Get([FromQuery]int year , [FromQuery] int month , [FromQuery] int day) 
        {
            var date = new DateOnly(year, month, day);
            var data = _db.Orders.Where(c=>c.OrderDate == date).ToList();
            return Ok(data);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var order = _db.Orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound(); 
            }

            _db.Orders.Remove(order);

            _db.SaveChanges();

            return Ok(order);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.DTOs;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantitiesController : ControllerBase
    {
        private EcommerceCoreContext _db;
        public QuantitiesController(EcommerceCoreContext db)
        {
            _db = db;
        }
        [HttpPut]
        [Route("EditQuantity/{id}")]
        public IActionResult EditQuantity(int id, [FromBody] EditQuantityRequest Edit)
        {
            var data = _db.CartItems.Find(id);
            data.Quantity = Edit.Quantity;
            _db.CartItems.Update(data);
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteItem/{id}")]
        public IActionResult Item(int id)
        {
            var data = _db.CartItems.Find(id);
            _db.CartItems.Remove(data);
            _db.SaveChanges();
            return Ok();
        }
    }
}

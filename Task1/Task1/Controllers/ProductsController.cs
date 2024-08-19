using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private EcommerceCoreContext _db;
        public ProductsController(EcommerceCoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Product()
        {
            var data = _db.Products.ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Product(int id)
        {
            var data = _db.Products.Select(p => new
            {
                p.ProductId,
                p.CategoryId,
                p.Category,
                p.Description
            });
            return Ok(data);
        }
    }
}

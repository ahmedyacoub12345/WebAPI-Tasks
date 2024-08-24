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
        [Route("AllProducts/Product")]
        public IActionResult Product()
        {
            var data = _db.Products.ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("Product/{id}")]
        public IActionResult Product(int id)
        {
            var data = _db.Products.Where(p=> p.ProductId ==id);
            return Ok(data);
        }
        [HttpGet]
        [Route("products/{id:int:max(10)}")]
        public IActionResult Product(int id,[FromQuery] string name)
        {
            var data = _db.Products.Where(c=>c.ProductId==id && c.ProductName==name);
            return Ok(data);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var data = _db.Products.Find(id);
            _db.Products.Remove(data);
            _db.SaveChanges();
            return Ok(data);
        }
        //[HttpGet("{id}/{price}")]
        //public IActionResult Product(int id ,string price)
        //{
        //    var data = _db.Products.Where(p=> p.CategoryId == id && string.Compare(p.Price ,price)>0).Count();
        //    return Ok(data);
        //}
    }
}

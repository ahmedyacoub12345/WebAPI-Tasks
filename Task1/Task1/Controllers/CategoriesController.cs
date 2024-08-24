using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private EcommerceCoreContext _db;
        public CategoriesController(EcommerceCoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("AllCategories/Category")]
        public IActionResult Category()
        {
            var data = _db.Categories.ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("{id:int:min(3)}")]
        public IActionResult Category(int id)
        {
            var data = _db.Categories.Find(id);
            return Ok(data);
        }
        [HttpGet]
        [Route("{name}")]
        public IActionResult Category(string name) 
        {
            var data = _db.Categories.FirstOrDefault(c => c.CategoryName == name);
            return Ok(data);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _db.Categories.Find(id);
            _db.Categories.Remove(data);
            _db.SaveChanges();
            return Ok(data);
        }

        
    }
}

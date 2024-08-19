using Microsoft.AspNetCore.Http;
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
        public IActionResult Category()
        {
            var data = _db.Categories.ToList();
            return Ok(data);
        }
        
        [HttpGet ("{id}")]
        public IActionResult Category(int id)
        {
            var data = _db.Categories.Find(id);
            return Ok(data);
        }
        
    }
}

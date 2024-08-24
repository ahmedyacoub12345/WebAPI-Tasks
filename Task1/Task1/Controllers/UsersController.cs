using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private EcommerceCoreContext _db;
        public UsersController(EcommerceCoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("AllUsers/User")]
        public IActionResult Get() 
        {
            var data =_db.Users.ToList();
            return Ok(data);
        }
        [HttpGet]
        [Route("User/{id}")]
        public IActionResult Get(int id) 
        {
            var data = _db.Users.Find(id);
            return Ok(data);
        }
        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name) 
        {
            var data = _db.Users.FirstOrDefault(c=> c.Username == name);
            return Ok(data);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id) 
        {
            var data = _db.Users.Find(id);
            _db.Users.Remove(data);
            _db.SaveChanges();
            return Ok(data);
        }
    }
}

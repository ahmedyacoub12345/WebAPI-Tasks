using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.DTOs;
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
        [HttpPost]
        [Route("AddUsers")]
        public IActionResult AddUsers([FromForm] UserRequestDTO user )
        {

            var dataResponse = new User
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email
            };

            _db.Users.Add(dataResponse);
            _db.SaveChanges();
            return Ok(user);

        }
        [HttpPut]
        [Route ("UpdateUser/{id:int}")]
        public IActionResult UpdateUser(int id , [FromForm]UserRequestDTO user)
        {
            var data = _db.Users.Find(id);
            data.Username = user.Username;
            data.Password = user.Password;
            data.Email = user.Email;
            _db.Users.Update(data);
            _db.SaveChanges();
            return Ok(user);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Task1.DTOs;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private EcommerceCoreContext _db;
        private readonly TokenGenerator _tokenGenerator;
        public UsersController(EcommerceCoreContext db , TokenGenerator tokenGenerator)
        {
            _db = db;
            _tokenGenerator = tokenGenerator;
        }
        [HttpGet]
        [Route("AllUsers/User")]
        public IActionResult Get()
        {
            var data = _db.Users.ToList();
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
            var data = _db.Users.FirstOrDefault(c => c.Username == name);
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
        public IActionResult AddUsers([FromForm] UserRequestDTO user)
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
        [Route("UpdateUser/{id:int}")]
        public IActionResult UpdateUser(int id, [FromForm] UserRequestDTO user)
        {
            var data = _db.Users.Find(id);
            data.Username = user.Username;
            data.Password = Hashing(user.Password);
            data.Email = user.Email;
            _db.Users.Update(data);
            _db.SaveChanges();
            return Ok(user);
        }

        private string Hashing(string password)
        {


            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                {

                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
     

        [HttpPost("Register")]
        public IActionResult Register([FromForm] UserRequestDTO user)
        {

            if (user == null)
            {
                return BadRequest("invalid input");
            }

            if (user.Password != null)
            {

                var user1 = new User
                {
                    Username = user.Username,
                    Password = Hashing(user.Password),
                    Email = user.Email,
                };

                _db.Users.Add(user1);
                _db.SaveChanges();
                return Ok(user1);

            }
            else
            {
                return BadRequest("password cant be null");
            }
        }

        [HttpGet("Login")]
        public IActionResult Login([FromQuery] LoginDTO user)
        {

            if (user == null)
            {

                return BadRequest("input can't be null");

            }

            var record = _db.Users.FirstOrDefault(u => u.Username == user.Username);

            if (record != null && user.Password != null)
            {

                var input_pass = Hashing(user.Password);
                var real_pass = record.Password;

                if (real_pass != input_pass)
                {
                    return BadRequest("uncorrect password");
                }
                else
                {
                    var roles = _db.UserRoles.Where(x => x.UserId == user.Id).Select(ur => ur.Role).ToList();
                    var token = _tokenGenerator.GenerateToken(user.Username, roles);
                    return Ok(new { Token = token, user.Id });
                }
            }
            return BadRequest("input is null");

        }
        [HttpPost("LoginPost")]
        public IActionResult LoginPost([FromBody] LoginDTO user)
        {
            if (user == null)
            {

                return BadRequest("input can't be null");

            }
            var record = _db.Users.FirstOrDefault(u => u.Username == user.Username);
            if (record != null && user.Password != null)
            {

                var input_pass = Hashing(user.Password);
                var real_pass = record.Password;

                if (real_pass != input_pass)
                {
                    return BadRequest("uncorrect password");
                }
                else
                {
                    var roles = _db.UserRoles.Where(x => x.UserId == user.Id).Select(ur => ur.Role).ToList();
                    var token = _tokenGenerator.GenerateToken(user.Username, roles);
                    return Ok(new { Token = token ,user.Id});
                }
            }

            return BadRequest("input is null");
        }
        [HttpPost("ProblemSolving")]
        public IActionResult ProblemSolving([FromForm] string text)
        {

            var numbers = text.Trim().Split(' ').Select(n => int.Parse(n)).ToList();

            Dictionary<int, int> result = new Dictionary<int, int>();

            // { key : value }

            foreach (var number in numbers)
            {
                if (result.ContainsKey(number))
                {
                    result[number]++; // this is mean result[number] = result[number] + 1 ;
                }
                else
                {
                    result.Add(number, 1);
                }
            }

            foreach (var item in result)
            {
                if (item.Value % 2 == 1)
                {
                    return Ok(item);
                }
            }

            return Ok(result);
        }

    }
}

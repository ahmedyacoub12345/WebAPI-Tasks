using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Task1.DTOs;
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
        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory([FromForm] categoryRequestDTO categoryDto)
        {
            var uploadedFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadedFolder))
            {
                Directory.CreateDirectory(uploadedFolder);
            }
            var fileImage = Path.Combine(uploadedFolder, categoryDto.CategoryImage.FileName);
            using (var stream = new FileStream(fileImage, FileMode.Create))
            {
                categoryDto.CategoryImage.CopyToAsync(stream);

            }
            var dataResponse = new Category
            {
                CategoryImage = categoryDto.CategoryImage.FileName,
                CategoryName = categoryDto.CategoryName
            };

            _db.Categories.Add(dataResponse);
            _db.SaveChanges();

            return Ok(new { message = "Category added successfully", dataResponse });
        }
        [HttpPut]
        [Route("UpdateCategory/${id:int}")]
        public IActionResult EditCategory(int id, [FromForm] categoryRequestDTO category)
        {

            var existCategory = _db.Categories.Find(id);
            if (existCategory == null)
            {
                return NotFound();
            }
            var uploadedFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadedFolder))
            {
                Directory.CreateDirectory(uploadedFolder);
            }
            var fileImage = Path.Combine(uploadedFolder, category.CategoryImage.FileName);
            using (var stream = new FileStream(fileImage, FileMode.Create))
            {
                category.CategoryImage.CopyToAsync(stream);

            }
            existCategory.CategoryName=category.CategoryName;
            existCategory.CategoryImage = category.CategoryImage.FileName;
            
            _db.SaveChanges();
            return Ok(existCategory);
        }
        

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.DTOs;
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
        [Authorize]
        public IActionResult Product()
        {
            var data = _db.Products.OrderByDescending(x => x.ProductName).ToList().TakeLast(5);
            //var d = data.OrderByDescending(x=> x.ProductName).TakeLast(5);
            return Ok(data);
        }

        [HttpGet]
        [Route("Product/{id}")]
        public IActionResult Product(int id)
        {
            var data = _db.Products.Where(p => p.ProductId == id);
            return Ok(data);
        }
        [HttpGet]
        [Route("products/{id:int:max(10)}")]
        public IActionResult Product(int id, [FromQuery] string name)
        {
            var data = _db.Products.Where(c => c.ProductId == id && c.ProductName == name);
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
        [HttpGet("Category/{id}")]
        public IActionResult product(int id)
        {
            var data = _db.Products.Where(p => p.CategoryId == id).ToList();
            return Ok(data);
        }
        [HttpGet]
        [Route("Sorting/")]
        public IActionResult ProductSort()
        {
            var data = _db.Products.OrderByDescending(x =>  Convert.ToDecimal( x.Price)).ToList();
            return Ok(data);
        }

        [HttpPost]
        [Route ("AddProducts")]
        public IActionResult AddProducts([FromForm] ProductRequestDTO product)
        {
            var uploadedFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadProductImage");
            if (!Directory.Exists(uploadedFolder))
            {
                Directory.CreateDirectory(uploadedFolder);
            }
            var fileImage = Path.Combine(uploadedFolder, product.ProductImage.FileName);
            using (var stream = new FileStream(fileImage, FileMode.Create))
            {
                product.ProductImage.CopyToAsync(stream);
            }
            var dataResponse = new Product
            {
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ProductImage = product.ProductImage.FileName
            };

            _db.Products.Add(dataResponse);
            _db.SaveChanges();

            return Ok(dataResponse);
        }
        [HttpPut]
        [Route ("UpdateProduct/{id:int}")]
        public IActionResult update(int id, [FromForm] ProductRequestDTO product)
        {
            var uploadedFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadProductImage");
            if (!Directory.Exists(uploadedFolder))
            {
                Directory.CreateDirectory(uploadedFolder);
            }
            var fileImage = Path.Combine(uploadedFolder, product.ProductImage.FileName);
            using (var stream = new FileStream(fileImage, FileMode.Create))
            {
                product.ProductImage.CopyToAsync(stream);
            }
            var data = _db.Products.Find(id);
            data.ProductName = product.ProductName;
            data.Description = product.Description;
            data.Price = product.Price;
            data.CategoryId = product.CategoryId;
            data.ProductImage = product.ProductImage.FileName;
          
            _db.Products.Update(data);
            _db.SaveChanges();
            return Ok(data);

        }

    }
}

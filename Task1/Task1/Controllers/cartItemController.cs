using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.DTOs;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cartItemController : ControllerBase
    {

        private EcommerceCoreContext _db;

        public cartItemController(EcommerceCoreContext db) {

            _db = db;

        }

        [HttpGet("GetCarts")]
        public ActionResult GetCarts() {

            var data = _db.CartItems.Select(x => new cartItemResponseDTO
            {
                CartId = x.CartId,
                CartItemId = x.CartItemId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                ProductRequest = new ProductRequestDTO
                {
                    CategoryId = x.Product.CategoryId,
                    ProductName = x.Product.ProductName,
                    Description = x.Product.Description,
                    Price = x.Product.Price

                }
            });

            return Ok(data);
        }
        [HttpPost]
        [Route("AddCartItem")]
        public IActionResult addCartItem([FromBody] AddCartRequestDTO cart)
        {
            var data = new CartItem
            {
                CartId = cart.CartId,
                Quantity = cart.Quantity,
                ProductId = cart.ProductId,
            };
            _db.CartItems.Add(data);
            _db.SaveChanges();
            return Ok();
        }

    }
}

using Task1.Models;

namespace Task1.DTOs
{
    public class cartItemResponseDTO
    {

        public int CartItemId { get; set; }

        public int? CartId { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }

        public ProductRequestDTO ProductRequest { get; set; }
    }
    public class ProductRequist
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public string? Price { get; set; }


    }
}

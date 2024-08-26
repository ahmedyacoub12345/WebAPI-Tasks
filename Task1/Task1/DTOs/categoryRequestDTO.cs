using Task1.Models;

namespace Task1.DTOs
{
    public class categoryRequestDTO
    {

        public string? CategoryName { get; set; }

        public IFormFile? CategoryImage { get; set; }

    }
}

﻿using Task1.Models;

namespace Task1.DTOs
{
    public class ProductRequestDTO
    {

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public string? Price { get; set; }

        public int? CategoryId { get; set; }

        public IFormFile? ProductImage { get; set; }

    }
}

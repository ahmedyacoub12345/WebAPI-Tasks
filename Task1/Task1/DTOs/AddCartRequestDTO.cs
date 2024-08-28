namespace Task1.DTOs
{
    public class AddCartRequestDTO
    {
        public int? CartId { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

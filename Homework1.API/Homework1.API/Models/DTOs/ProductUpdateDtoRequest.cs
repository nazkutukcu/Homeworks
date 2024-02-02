namespace Homework1.API.Models.DTOs
{
    public class ProductUpdateDtoRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}

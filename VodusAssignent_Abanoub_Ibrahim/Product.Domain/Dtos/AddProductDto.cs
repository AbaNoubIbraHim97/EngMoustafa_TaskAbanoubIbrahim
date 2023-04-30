using System.ComponentModel.DataAnnotations;

namespace Product.Domain.Dtos
{
    public class AddProductDto
    {
        [MinLength(3, ErrorMessage = "Name must be at least 3  characters"),]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 1")]
        public decimal Price { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
}

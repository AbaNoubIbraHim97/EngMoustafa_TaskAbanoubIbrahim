using System.ComponentModel.DataAnnotations;

namespace Product.Domain.Models
{
    public class Product
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Name must be at least 3  characters"),]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 1")]
        [Required]
        public decimal Price { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}

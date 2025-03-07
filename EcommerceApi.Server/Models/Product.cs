using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Server.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9\s\-]{3,100}$", ErrorMessage = "Product name must be 3-100 characters long and can contain letters, numbers, spaces, and dashes.")]
        public required string Name { get; set; }

        [Required]
        [RegularExpression(@"^[\w\s\.,!?-]{10,255}$", ErrorMessage = "Description must be between 10-255 characters.")]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000.")]
        public required decimal Price { get; set; }

        public string? ImagePath { get; set; } // Store the file path instead of a URL

        [ForeignKey("CategoryId")]
        public Category? category { get; set; }

    }

}

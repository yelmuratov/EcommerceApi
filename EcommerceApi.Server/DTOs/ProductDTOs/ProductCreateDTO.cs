using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Server.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0.1, 100000, ErrorMessage = "Price must be between 0.1 and 100,000")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}

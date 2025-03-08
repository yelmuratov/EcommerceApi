using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Server.DTOs.CategoryDTOs
{
    public class CategoryCreateDTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "Category name must be between 1 and 50 characters", MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}

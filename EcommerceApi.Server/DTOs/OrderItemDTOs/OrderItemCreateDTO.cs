using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Server.DTOs.OrderItemDTOs
{
    public class OrderItemCreateDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Quantity must be between 1 and 10,000")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.1, 100000, ErrorMessage = "Unit Price must be between 0.1 and 100,000")]
        public decimal UnitPrice { get; set; }
    }
}

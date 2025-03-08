using EcommerceApi.Server.DTOs.OrderItemDTOs;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Server.DTOs.OrderDTOs
{
    public class OrderCreateDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public List<OrderItemCreateDTO> OrderItems { get; set; } = new();
    }
}

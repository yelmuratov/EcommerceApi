using EcommerceApi.Server.Constants;
using EcommerceApi.Server.DTOs.OrderItemDTOs;

namespace EcommerceApi.Server.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatuses OrderStatus { get; set; }
        public PaymentStatuses PaymentStatus { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}

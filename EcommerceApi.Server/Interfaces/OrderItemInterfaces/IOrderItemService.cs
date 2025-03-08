using EcommerceApi.Server.Models;

namespace EcommerceApi.Server.Interfaces.OrderItemInterfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItems();
        Task<OrderItem> GetOrderItemById(int id);
        Task<OrderItem> CreateOrderItem(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
        Task<bool> DeleteOrderItem(int id);
    }
}

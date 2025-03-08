using EcommerceApi.Server.Models;

namespace EcommerceApi.Server.Interfaces.OrderItemInterfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<OrderItem?> GetByIdAsync(int id);
        Task<OrderItem> AddAsync(OrderItem order);
        Task<OrderItem> UpdateAsync(OrderItem order);
        Task<bool> DeleteAsync(int id);

    }
}

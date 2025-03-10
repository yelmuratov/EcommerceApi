using EcommerceApi.Server.Models;
namespace EcommerceApi.Server.Interfaces.OrderInterfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Order> AddAsync(Order order);
        Task<Order> UpdateAsync(Order order);
        Task<bool> DeleteAsync(int id);
    }
}

using EcommerceApi.Server.DTOs.OrderDTOs;
using EcommerceApi.Server.Models;

namespace EcommerceApi.Server.Interfaces.OrderInterfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(OrderCreateDTO order);
        Task<Order> UpdateOrder(OrderDTO order);
        Task<bool> DeleteOrder(int id);
    }
}

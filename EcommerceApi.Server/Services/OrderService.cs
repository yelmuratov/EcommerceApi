using AutoMapper;
using EcommerceApi.Server.DTOs.OrderDTOs;
using EcommerceApi.Server.Interfaces.OrderInterfaces;
using EcommerceApi.Server.Models;
using EcommerceApi.Server.Interfaces.UserInterfaces;

namespace EcommerceApi.Server.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {id} not found.");
            }
            return order;
        }

        public async Task<Order> CreateOrder(OrderCreateDTO orderDto)
        {
            var user = await _userRepository.GetByIdAsync(orderDto.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {orderDto.UserId} not found.");
            }

            var newOrder = _mapper.Map<Order>(orderDto);
            newOrder.User = user;

            return await _orderRepository.AddAsync(newOrder);
        }

        public async Task<Order> UpdateOrder(OrderDTO orderDto)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderDto.Id);
            if (existingOrder == null)
            {
                throw new KeyNotFoundException($"Order with ID {orderDto.Id} not found.");
            }

            _mapper.Map(orderDto, existingOrder);
            return await _orderRepository.UpdateAsync(existingOrder);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {id} not found.");
            }

            var deletedOrder = await _orderRepository.DeleteAsync(id);

            return deletedOrder != null;
        }
    }
}

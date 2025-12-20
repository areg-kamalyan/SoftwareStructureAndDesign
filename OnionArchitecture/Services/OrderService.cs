using Domain.Entities;
using Domain.Interfaces;
using Services.DTOs;
using Services.Interfaces;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderNumberGenerator _generator;
        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, IOrderNumberGenerator generator)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _generator = generator;
        }

        public async Task<Order> CreateOrderAsync(OrderDto data, CancellationToken ct = default)
        {
            var existingUser = await _userRepository.GetByIdAsync(data.UserId);

            if (existingUser is null)
            {
                throw new InvalidOperationException($"User with ID {data.UserId} do not exists.");
            }
            var order = new Order(_generator.Generate(), data.UserId, data.Title, data.Details, data.Price);
            await _orderRepository.AddAsync(order, ct);
            return order;
        }

        public async Task<Order> GetOrderAsync(string orderNumber)
        {
            var order = await _orderRepository.GetByNumberAsync(orderNumber);

            if (order is null)
            {
                throw new InvalidOperationException($"Order with ID {orderNumber} does not exist.");
            }

            return order;
        }

        public async Task ShipOrderAsync(string orderNumber)
        {
            var order = await _orderRepository.GetByNumberAsync(orderNumber);
            if (order == null)
            {
                throw new InvalidOperationException($"Order {orderNumber} not found.");
            }

            // Business logic execution within the domain model
            order.MarkAsShipped();

            await _orderRepository.SaveAsync(order);
        }
    }
}

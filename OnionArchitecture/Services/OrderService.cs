using Domain.Entities;
using Services.Interfaces.Repositories;
using Services.Interfaces.Services;
using Services.Commands;
using Services.DTOs;
using Services.Querys;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderCommand command, CancellationToken ct = default)
        {
            var existingUser = await _userRepository.GetByIdAsync(command.UserId);

            if (existingUser is null)
            {
                throw new InvalidOperationException($"User with ID {command.UserId} do not exists.");
            }
            var order = new Order(command.UserId, command.Title, command.Details, command.Price);
            await _orderRepository.AddAsync(order, ct);
            return new OrderDto(order.Id, order.Status.ToString());
        }

        public async Task<Order> GetOrderAsync(GetOrderQuery query)
        {
            var order = await _orderRepository.GetByIdAsync(query.OrderId);

            if (order is null)
            {
                throw new InvalidOperationException($"Order with ID {query.OrderId} does not exist.");
            }

            return order;
        }

        public async Task ShipOrderAsync(ShipOrderCommand command)
        {
            var order = await _orderRepository.GetByIdAsync(command.OrderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order {command.OrderId} not found.");
            }

            // Business logic execution within the domain model
            order.MarkAsShipped();

            await _orderRepository.SaveAsync(order);
        }
    }
}

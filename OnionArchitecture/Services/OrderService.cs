using Domain.Entities;
using Domain.Interfaces;
using Services.Requests;

namespace Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateOrderAsync(CreateOrderRequest request, CancellationToken ct = default)
        {

            var existingUser = await _userRepository.GetByIdAsync(request.UsersId);

            if (existingUser is null)
            {
                throw new InvalidOperationException($"User with ID {request.UsersId} do not exists.");
            }
            var order = new Order(request.UsersId, request.Title, request.Details, request.Price);
            await _orderRepository.AddAsync(order, ct);
            return order.Id;
        }

        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null)
            {
                throw new InvalidOperationException($"Order with ID {orderId} does not exist.");
            }

            return order;
        }

        public async Task ShipOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order {orderId} not found.");
            }

            // Business logic execution within the domain model
            order.MarkAsShipped();

            await _orderRepository.SaveAsync(order);
        }
    }
}

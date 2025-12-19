using Application.Interfaces.Messaging;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;

namespace Application.UseCases.Orders.ShipOrder
{
    // Application/UseCases/ShipOrderHandler.cs
    // A use case handler (often using libraries like MediatR for CQRS)
    public class ShipOrderUseCase : IShipOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderShippedEventPublisher _publisher;

        public ShipOrderUseCase(IOrderRepository orderRepository, IOrderShippedEventPublisher publisher)
        {
            _orderRepository = orderRepository;
            _publisher = publisher;
        }

        public async Task ExecuteAsync(ShipOrderCommand command)
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

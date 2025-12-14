using Application.Interfaces;

namespace Application.UseCases
{
    // Application/UseCases/ShipOrderHandler.cs
    // A use case handler (often using libraries like MediatR for CQRS)
    public class ShipOrderHandler
    {
        private readonly IOrderRepository _orderRepository;

        public ShipOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Execute(Guid orderId)
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

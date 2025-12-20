using Application.Ports.Input;
using Application.Ports.Output;

namespace Application.UseCases.Orders
{
    public class ShipOrderUseCase : IShipOrderUseCase
    {
        private readonly IOrderRepository _orderRepository; 
        private readonly IOrderShippedEventPublisher _publisher;

        public ShipOrderUseCase(IOrderRepository orderRepository, IOrderShippedEventPublisher publisher)
        {
            _orderRepository = orderRepository; 
            _publisher = publisher;
        }

        public async Task ExecuteAsync(string orderNumber)
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

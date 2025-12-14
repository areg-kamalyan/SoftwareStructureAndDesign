using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class GetOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> ExecuteAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null)
            {
                throw new InvalidOperationException($"Order with ID {orderId} does not exist.");
            }

            return order;
        }
    }

}

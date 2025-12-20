using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;
using Domain.Entities;

namespace Application.UseCases.Orders
{
    public class GetOrderUseCase : IGetOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> ExecuteAsync(string orderNumber)
        {
            var order = await _orderRepository.GetByNumberAsync(orderNumber);

            if (order is null)
            {
                throw new InvalidOperationException($"Order with ID {orderNumber} does not exist.");
            }

            return order;
        }
    }

}

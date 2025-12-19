using Application.Ports.Input;
using Application.Ports.Output;
using Domain.Entities;

namespace Application.UseCases.Orders.GetOrder
{
    public class GetOrderUseCase : IGetOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> ExecuteAsync(GetOrderQuery query)
        {
            var order = await _orderRepository.GetByIdAsync(query.OrderId);

            if (order is null)
            {
                throw new InvalidOperationException($"Order with ID {query.OrderId} does not exist.");
            }

            return order;
        }
    }

}

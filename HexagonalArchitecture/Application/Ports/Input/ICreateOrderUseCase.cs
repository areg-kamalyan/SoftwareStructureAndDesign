using Application.DTOs;
using Application.UseCases.Orders.CreateOrder;

namespace Application.Ports.Input
{
    public interface ICreateOrderUseCase
    {
        Task<OrderDto> ExecuteAsync(CreateOrderCommand command, CancellationToken ct = default);
    }
}

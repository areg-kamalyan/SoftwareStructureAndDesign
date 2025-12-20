using Application.DTOs;
using Domain.Entities;

namespace Application.Ports.Input
{
    public interface ICreateOrderUseCase
    {
        Task<Order> ExecuteAsync(OrderDto data, CancellationToken ct = default);
    }
}

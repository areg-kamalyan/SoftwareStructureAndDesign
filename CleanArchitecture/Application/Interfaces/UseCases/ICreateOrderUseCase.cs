using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.UseCases
{
    public interface ICreateOrderUseCase
    {
        Task<Order> ExecuteAsync(OrderDto data, CancellationToken ct = default);
    }
}

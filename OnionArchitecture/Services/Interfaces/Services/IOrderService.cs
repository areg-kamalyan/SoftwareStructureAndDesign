using Domain.Entities;
using Services.Commands;
using Services.DTOs;
using Services.Querys;

namespace Services.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderCommand command, CancellationToken ct = default);
        Task<Order> GetOrderAsync(GetOrderQuery query);
        Task ShipOrderAsync(ShipOrderCommand command);

    }
}

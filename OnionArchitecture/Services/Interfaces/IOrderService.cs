using Domain.Entities;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderDto data, CancellationToken ct = default);
        Task<Order> GetOrderAsync(string orderNumber);
        Task ShipOrderAsync(string orderNumber);

    }
}

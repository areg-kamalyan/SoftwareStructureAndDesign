using Domain.Entities;

namespace Services.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByNumberAsync(string Number);
        Task SaveAsync(Order order);
        Task AddAsync(Order order, CancellationToken ct = default);

    }

}

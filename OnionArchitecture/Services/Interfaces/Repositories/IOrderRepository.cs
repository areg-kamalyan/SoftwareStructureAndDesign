using Domain.Entities;

namespace Services.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task SaveAsync(Order order);
        Task AddAsync(Order order, CancellationToken ct = default);

    }

}

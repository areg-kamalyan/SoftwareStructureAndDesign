using Domain.Entities;

namespace Application.Ports.Output
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task SaveAsync(Order order);
        Task AddAsync(Order order, CancellationToken ct = default);

    }

}

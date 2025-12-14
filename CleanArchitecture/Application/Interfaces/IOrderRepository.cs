using Domain.Entities;

namespace Application.Interfaces
{
    // Application/Interfaces/IOrderRepository.cs
    // The contract is in Application, the implementation is in Infrastructure
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task SaveAsync(Order order);
        Task AddAsync(Order order, CancellationToken ct = default);

    }

}

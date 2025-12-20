using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    // Application/Interfaces/Repositories/IOrderRepository.cs
    // The contract is in Application, the implementation is in Infrastructure
    public interface IOrderRepository
    {
        Task<Order> GetByNumberAsync(string Number);
        Task SaveAsync(Order order);
        Task AddAsync(Order order, CancellationToken ct = default);

    }

}

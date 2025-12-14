using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid Id);
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}

using Domain.Entities;

namespace Services.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid Id);
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}

using Domain.Entities;

namespace Application.Ports.Output
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid Id);
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}

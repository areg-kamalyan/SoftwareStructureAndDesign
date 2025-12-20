using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            // Ensure the database is created
            context.Database.EnsureCreated();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByIdAsync(Guid UserId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

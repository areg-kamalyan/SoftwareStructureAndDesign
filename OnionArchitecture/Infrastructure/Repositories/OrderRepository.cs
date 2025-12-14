using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
            // Ensure the database is created
            context.Database.EnsureCreated();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task SaveAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(Order order, CancellationToken ct = default)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(ct);
        }
    }
}

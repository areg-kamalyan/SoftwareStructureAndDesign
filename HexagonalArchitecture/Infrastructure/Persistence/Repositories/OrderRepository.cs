
using Application.Ports.Output;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    // Infrastructure/Data/EfOrderRepository.cs
    // Implements the interface defined in the Application layer
    internal class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
            // Ensure the database is created
            context.Database.EnsureCreated();
        }

        public async Task<Order> GetByNumberAsync(string orderNumber)
        {
            return await _context.Orders.FirstOrDefaultAsync(u => u.Number == orderNumber);
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

using GeradorNotaFiscal.Data;
using GeradorNotaFiscal.interfaces.repositories;
using GeradorNotaFiscal.models;
using Microsoft.EntityFrameworkCore;

namespace GeradorNotaFiscal.repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task deleteAsync(Guid id)
        {
            await _context.Orders
                    .Where(o => o.id == id)
                    .ExecuteDeleteAsync();
        }

        public async Task<List<Order>> getAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> getAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> createAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> updateAsync(Order order)
        {
            await _context.SaveChangesAsync();
            return order;
        }
    }
}

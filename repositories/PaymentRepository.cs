using GeradorNotaFiscal.Data;
using GeradorNotaFiscal.interfaces.repositories;
using GeradorNotaFiscal.models;
using Microsoft.EntityFrameworkCore;

namespace GeradorNotaFiscal.repositories
{
    public class PaymentRepository : IPaymentRepository
    {

        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Payment>> getAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> getAsync(Guid id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<Payment> createAsync(Payment payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> updateAsync(Payment payment)
        {
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}

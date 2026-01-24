using GeradorNotaFiscal.Data;
using GeradorNotaFiscal.interfaces.repositories;
using GeradorNotaFiscal.models;
using Microsoft.EntityFrameworkCore;

namespace GeradorNotaFiscal.repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task deleteAsync(Guid id)
        {
            await _context.Invoices
                    .Where(i => i.id == id)
                    .ExecuteDeleteAsync();
        }

        public async Task<List<Invoice>> getAllAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> getAsync(Guid id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task<Invoice> saveAsync(Invoice invoice)
        {
            await _context.AddAsync(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }
    }
}

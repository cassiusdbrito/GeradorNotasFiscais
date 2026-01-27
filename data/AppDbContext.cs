using GeradorNotaFiscal.models;
using GeradorNotaFiscal.utils;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace GeradorNotaFiscal.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IDataProtectionProvider _provider;
        public AppDbContext(DbContextOptions<AppDbContext> options,
                IDataProtectionProvider provider
            )     
            : base(options)
        {
            _provider = provider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var protector = _provider.CreateProtector("ClientDocumentProtector");

            modelBuilder.Entity<Order>()
                .Property(o => o.clientDocument)
                .HasConversion(new DataProtectionConverter(protector));
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}

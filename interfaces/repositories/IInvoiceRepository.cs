using GeradorNotaFiscal.models;

namespace GeradorNotaFiscal.interfaces.repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> saveAsync(Invoice invoice);
        Task<Invoice> getAsync(Guid id);
        Task<List<Invoice>> getAllAsync();
        Task deleteAsync(Guid id);
    }
}

using GeradorNotaFiscal.dto.invoice;

namespace GeradorNotaFiscal.interfaces.services
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> generateInvoice(InvoiceCreateDto createInvoiceDto);
        Task<List<InvoiceDto>> getAllInvoices();
        Task<InvoiceDto> getInvoiceById(Guid id);
        Task deleteInvoiceById(Guid id);

        Task<InvoiceDto> getInvoiceByPaymentId(Guid paymentId);
    }
}

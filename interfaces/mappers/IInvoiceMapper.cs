using GeradorNotaFiscal.dto.invoice;
using GeradorNotaFiscal.models;

namespace GeradorNotaFiscal.interfaces.mappers
{
    public interface IInvoiceMapper
    {
        InvoiceDto toDto(Invoice invoice);
        Invoice toEntity(InvoiceCreateDto dto);
    }
}

using GeradorNotaFiscal.dto.invoice;
using GeradorNotaFiscal.interfaces.mappers;
using GeradorNotaFiscal.models;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace GeradorNotaFiscal.mappers
{
    public class InvoiceMapper : IInvoiceMapper
    {
        public InvoiceDto toDto(Invoice invoice)
        {
            return new InvoiceDto()
            {
                id = invoice.id,
                paymentId = invoice.paymentId,
                invoiceNumber = invoice.invoiceNumber,
                emissionDate = invoice.emissionDate,
                invoiceValue = invoice.invoiceValue 
            };
        }

        public Invoice toEntity(InvoiceCreateDto dto)
        {
            var newInvoice = new Invoice
            {
                paymentId = dto.paymentId,
                invoiceNumber = dto.invoiceNumber,
                emissionDate = dto.emissionDate,
                invoiceValue = dto.invoiceValue
            };

            return newInvoice;
        }
    }
}

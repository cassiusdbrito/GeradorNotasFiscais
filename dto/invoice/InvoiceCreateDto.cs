using GeradorNotaFiscal.utils;

namespace GeradorNotaFiscal.dto.invoice
{
    public class InvoiceCreateDto
    {
        public Guid paymentId { get; set; }
        public string invoiceNumber { get; set; } = InvoiceGenerator.GenerateInvoiceNumber();
        public DateTime emissionDate { get; set; } = DateTime.UtcNow;
        public decimal invoiceValue { get; set; }
    }
}

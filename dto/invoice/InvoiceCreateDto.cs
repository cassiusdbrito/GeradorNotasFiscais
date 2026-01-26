using GeradorNotaFiscal.utils;
using System.ComponentModel.DataAnnotations;

namespace GeradorNotaFiscal.dto.invoice
{
    public class InvoiceCreateDto
    {
        [Required]
        public Guid paymentId { get; set; }

        [Required]
        public string invoiceNumber { get; set; } = InvoiceGenerator.GenerateInvoiceNumber();

        [Required]
        public DateTime emissionDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal invoiceValue { get; set; }
    }
}

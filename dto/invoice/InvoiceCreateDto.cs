namespace GeradorNotaFiscal.dto.invoice
{
    public class InvoiceCreateDto
    {
        public Guid paymentId { get; set; }
        public string invoiceNumber { get; set; }
        public DateTime emissionDate { get; set; }
        public decimal invoiceValue { get; set; } 
    }
}

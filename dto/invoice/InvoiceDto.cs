namespace GeradorNotaFiscal.dto.invoice
{
    public record InvoiceDto
    {
        public Guid id { get; init; }
        public Guid paymentId { get; init; }
        public string invoiceNumber { get; init; }
        public DateTime emissionDate { get; init; }
        public decimal invoiceValue { get; init; }
    }
}

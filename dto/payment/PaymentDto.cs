namespace GeradorNotaFiscal.dto.payment
{
    public record PaymentDto
    {
        public Guid id { get; init; }
        public Guid orderId { get; init; }
        public string paymentMethod { get; init; }
        public decimal valuePaid { get; init; }
        public DateTime paymentDate { get; init; }
        public string status { get; init; }
    }
}

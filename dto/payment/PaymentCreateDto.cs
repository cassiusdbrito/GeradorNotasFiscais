using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.dto.payment
{
    public record PaymentCreateDto
    {
        public Guid orderId { get; init; }
        public MethodPaymentEnum paymentMethod { get; init; }
        public decimal valuePaid { get; init; }
        public DateTime paymentDate { get; init; }
        public  PaymentStatusEnum status { get; init; }
    }
}

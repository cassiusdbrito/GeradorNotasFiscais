using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.dto.payment
{
    public record PaymentUpdateDto
    {
        public DateTime paymentDate { get; init; } = DateTime.UtcNow;
        public MethodPaymentEnum paymentMethod { get; init; }
        public PaymentStatusEnum status { get; init; }
    }
}

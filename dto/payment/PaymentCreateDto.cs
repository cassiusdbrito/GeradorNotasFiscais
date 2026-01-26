using GeradorNotaFiscal.utils.enums;
using System.ComponentModel.DataAnnotations;

namespace GeradorNotaFiscal.dto.payment
{
    public record PaymentCreateDto
    {
        [Required]
        public Guid orderId { get; init; }

        [Required]
        public MethodPaymentEnum paymentMethod { get; init; }

        [Required]
        public decimal valuePaid { get; init; }

        [Required]
        public DateTime paymentDate { get; init; }

        [Required]
        public  PaymentStatusEnum status { get; init; }
    }
}

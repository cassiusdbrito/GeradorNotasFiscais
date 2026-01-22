using GeradorNotaFiscal.dto.payment;
using GeradorNotaFiscal.models;
using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.interfaces.mappers
{
    public interface IPaymentMapper
    {
        PaymentDto toDto(Payment payment);
        string getPaymentMethod(MethodPaymentEnum method);
        Payment toEntity(PaymentCreateDto entity);
    }
}

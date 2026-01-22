using GeradorNotaFiscal.dto.payment;
using GeradorNotaFiscal.interfaces.mappers;
using GeradorNotaFiscal.models;
using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.mappers
{
    public class PaymentMapper : IPaymentMapper
    {
        public string getPaymentMethod(MethodPaymentEnum method)
        {
            switch (method)
            {
                case MethodPaymentEnum.CreditCard:
                    return "Cartão de crédito";
                case MethodPaymentEnum.DebitCard:
                    return "Cartão de débito";
                case MethodPaymentEnum.Pix:
                    return "Pix";
                case MethodPaymentEnum.BankSlip:
                    return "Boleto";
                case MethodPaymentEnum.Cash:
                    return "Dinheiro efetivo";
                default:
                    return "Não identificado";
            }
        }

        public PaymentDto toDto(Payment payment)
        {
            return new PaymentDto()
            {
                id = payment.id,
                orderId = payment.orderId,
                paymentMethod = getPaymentMethod(payment.paymentMethod),
                valuePaid = payment.valuePaid,
                paymentDate = payment.paymentDate,
            };
        }

        public Payment toEntity(PaymentCreateDto entity)
        {
            var newPayment = new Payment();
            newPayment.orderId = entity.orderId;
            newPayment.paymentMethod = entity.paymentMethod;
            newPayment.valuePaid = entity.valuePaid;
            newPayment.paymentDate = entity.paymentDate;
            newPayment.status = entity.status;

            return newPayment;
        }
    }
}

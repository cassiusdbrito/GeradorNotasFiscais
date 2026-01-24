using GeradorNotaFiscal.dto.invoice;
using GeradorNotaFiscal.dto.payment;

namespace GeradorNotaFiscal.interfaces.services
{
    public interface IPaymentService
    {
        Task<PaymentDto> processPayment(PaymentCreateDto createPaymentDto);
        Task<List<PaymentDto>> getAllPayments();
        Task<PaymentDto> getPaymentById(Guid id);
        Task<PaymentDto> updatePayment(Guid id, PaymentUpdateDto updatePaymentDto);
        Task cancelPayment(Guid id);
        Task<PaymentDto> getPaymentByOrderId(Guid orderId);

        Task<InvoiceDto> generateInvoice(Guid paymentId);
    }
}

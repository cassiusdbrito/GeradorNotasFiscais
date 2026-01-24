using GeradorNotaFiscal.models;

namespace GeradorNotaFiscal.interfaces.repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> saveAsync(Payment payment);
        Task<Payment> getAsync(Guid id);
        Task<List<Payment>> getAllAsync();
    }
}

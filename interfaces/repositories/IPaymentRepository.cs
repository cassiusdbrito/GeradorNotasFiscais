using GeradorNotaFiscal.models;

namespace GeradorNotaFiscal.interfaces.repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> createAsync(Payment payment);
        Task<Payment> getAsync(Guid id);
        Task<List<Payment>> getAllAsync();

        Task<Payment> updateAsync(Payment payment);
    }
}

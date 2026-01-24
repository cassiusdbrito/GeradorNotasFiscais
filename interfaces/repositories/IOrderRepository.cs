using GeradorNotaFiscal.models;

namespace GeradorNotaFiscal.interfaces.repositories
{
    public interface IOrderRepository
    {
        Task<Order> saveAsync(Order order);
        Task<Order> getAsync(Guid id);
        Task<List<Order>> getAllAsync();
        Task deleteAsync(Guid id);
    }
}

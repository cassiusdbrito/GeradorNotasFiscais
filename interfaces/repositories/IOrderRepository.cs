using GeradorNotaFiscal.models;

namespace GeradorNotaFiscal.interfaces.repositories
{
    public interface IOrderRepository
    {
        Task<Order> saveAsync(Order order);
        Task<Order> getAsync(Guid id);
        Task<List<Order>> getAllAsync();
        Task deleteAsync(Guid id);
        Task<Order> updateAsync (Guid id, Order order);
        Task<Order> findAllActiveAsync();
    }
}

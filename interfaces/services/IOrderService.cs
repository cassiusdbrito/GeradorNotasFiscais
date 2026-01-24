using GeradorNotaFiscal.dto.order;

namespace GeradorNotaFiscal.interfaces.services
{
    public interface IOrderService
    {
        Task<OrderDto> processOrder(CreateOrderDto createOrderDto);
        Task<List<OrderDto>> getAllOrders();
        Task<OrderDto> getOrderById(Guid id);
        Task<OrderDto> updateOrder(Guid id, OrderUpdateDto updateOrderDto);
        Task deleteOrder(Guid id);

    }
}

using GeradorNotaFiscal.dto.order;
using GeradorNotaFiscal.models;
using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.interfaces.mappers
{
    public interface IOrderMapper
    {
        OrderDto toDto(Order order);
        string getOrderStatus(OrderStatusEnum status);

        Order toEntity(CreateOrderDto dto);
    }
}

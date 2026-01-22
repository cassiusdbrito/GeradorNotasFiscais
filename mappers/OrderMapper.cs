using GeradorNotaFiscal.dto.order;
using GeradorNotaFiscal.interfaces.mappers;
using GeradorNotaFiscal.models;
using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.mappers
{
    public class OrderMapper : IOrderMapper
    {
        public string getOrderStatus(OrderStatusEnum status)
        {
            switch (status)
            {
                case OrderStatusEnum.Processing:
                    return "Processando pedido...";
                case OrderStatusEnum.Shipped:
                    return "Pedido enviado";
                case OrderStatusEnum.Delivered:
                    return "Pedido entregue";
                case OrderStatusEnum.Canceled:
                    return "Pedido cancelado";
                case OrderStatusEnum.Failed:
                    return "Falha ao executar pedido";
                default:
                    return "Status desconhecido";
            }
        }

        public OrderDto toDto(Order order)
        {
            return new OrderDto() {
                id = order.id,
                clientName = order.clientName,
                orderDate = order.orderDate,
                totalValue = order.totalValue,
                status = getOrderStatus(order.status)
            };
    }

        public Order toEntity(CreateOrderDto dto)
        {
            var newOrder = new Order();
            newOrder.clientName = dto.clientName;
            newOrder.clientDocument = dto.clientDocument;
            newOrder.orderDate = DateTime.Now;
            newOrder.totalValue = dto.totalValue;
            newOrder.status = dto.status;

            return newOrder;
        }
    }
}

using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.dto.order
{
    public record CreateOrderDto
    {
        public string clientName { get; init; }
        public string clientDocument { get; init; }
        public decimal totalValue { get; init; }
        public OrderStatusEnum status { get; set; }
    }
}

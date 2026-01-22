using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.dto.order
{
    public record OrderUpdateDto
    {
        public OrderStatusEnum status { get; set; }
    }
}

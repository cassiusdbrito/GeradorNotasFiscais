using GeradorNotaFiscal.utils.enums;
using System.ComponentModel.DataAnnotations;

namespace GeradorNotaFiscal.dto.order
{
    public record CreateOrderDto
    {
        [Required]
        public string clientName { get; init; }

        [Required]
        public string clientDocument { get; init; }

        [Required]
        public decimal totalValue { get; init; }

        [Required]
        public OrderStatusEnum status { get; set; }
    }
}

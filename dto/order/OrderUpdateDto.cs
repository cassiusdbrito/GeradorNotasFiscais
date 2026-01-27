using GeradorNotaFiscal.utils.enums;
using System.ComponentModel.DataAnnotations;

namespace GeradorNotaFiscal.dto.order
{
    public record OrderUpdateDto
    {
        [Required]
        public OrderStatusEnum status { get; set; }
    }
}

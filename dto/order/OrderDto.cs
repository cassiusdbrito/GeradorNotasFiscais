using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.dto.order
{
    public record OrderDto
    {
        public Guid id { get; init; }
        public string clientName { get; init; }
        public DateTime orderDate { get; init; }
        public decimal totalValue { get; init; }
        public string status { get; set; }
    }
}

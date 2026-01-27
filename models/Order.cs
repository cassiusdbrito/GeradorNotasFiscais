using GeradorNotaFiscal.utils.enums;
using System.ComponentModel.DataAnnotations;

namespace GeradorNotaFiscal.models
{
    public class Order
    {
        [Key]
        public Guid id { get; private set; } = Guid.NewGuid();

        [Required]
        public string clientName { get; set; }

        [Required]
        public string clientDocument { get; set; }

        [Required]
        public DateTime orderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal totalValue { get; set; }

        [Required]
        public OrderStatusEnum status { get; set; }

        public Order()
        {
        }

        public Order(string clientName, string clientDocument, DateTime orderDate, decimal totalValue, OrderStatusEnum status)
        {
            this.clientName = clientName;
            this.clientDocument = clientDocument;
            this.orderDate = orderDate;
            this.totalValue = totalValue;
            this.status = status;
        }
    }
}

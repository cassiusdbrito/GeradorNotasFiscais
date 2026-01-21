using GeradorNotaFiscal.utils.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeradorNotaFiscal.models
{
    public class Payment
    {
        [Key]
        private Guid id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Order")]
        public Guid orderId { get; set; }

        public Order order { get; set; }

        [Required]
        public MethodPaymentEnum paymentMethod { get; set; }

        [Required]
        public decimal valuePaid { get; set; }

        [Required]
        public DateTime paymentDate { get; set; }

        [Required]
        public PaymentStatusEnum status { get; set; } 

        public Payment()
        {
        }

        public Payment(Guid orderId, MethodPaymentEnum paymentMethod, decimal valuePaid, DateTime paymentDate, PaymentStatusEnum status)
        {
            this.orderId = orderId;
            this.paymentMethod = paymentMethod;
            this.valuePaid = valuePaid;
            this.paymentDate = paymentDate;
            this.status = status;
        }
    }
}

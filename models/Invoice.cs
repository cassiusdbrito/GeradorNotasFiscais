using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeradorNotaFiscal.models
{
    public class Invoice
    {
        [Key]
        public Guid id { get; private set; } = Guid.NewGuid();
        [Required]
        [ForeignKey("Payment")]
        public Guid paymentId { get; set; }
        public Payment payment { get; set; }

        [Required]
        public string invoiceNumber { get; set; }

        [Required]
        public DateTime emissionDate { get; set; }

        [Required]
        public decimal invoiceValue { get; set; }

        public Invoice() { }

        public Invoice(Guid paymentId, string invoiceNumber, DateTime emissionDate, decimal invoiceValue)
        {
            this.paymentId = paymentId;
            this.invoiceNumber = invoiceNumber;
            this.emissionDate = emissionDate;
            this.invoiceValue = invoiceValue;
        }
    }
}

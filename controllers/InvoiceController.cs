using GeradorNotaFiscal.interfaces.services;
using Microsoft.AspNetCore.Mvc;

namespace GeradorNotaFiscal.controllers
{
    [ApiController]
    [Route("api/notas-fiscais")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult getInvoices()
        {
            var invoices = _invoiceService.getAllInvoices();
            return new OkObjectResult(invoices);
        }

        [HttpGet("{id}")]
        public IActionResult getInvoiceById(Guid id)
        {
            var invoice = _invoiceService.getInvoiceById(id);
            return new OkObjectResult(invoice);
        }

        [HttpGet("nf-pagamento/{paymentId}")]
        public IActionResult getInvoiceByOrderId(Guid paymentId)
        {
            var invoice = _invoiceService.getInvoiceByPaymentId(paymentId);
            return new OkObjectResult(invoice);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteInvoiceById(Guid id)
        {
            _invoiceService.deleteInvoiceById(id);
            return NoContent();
        }
    }
}

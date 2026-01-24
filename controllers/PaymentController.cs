using GeradorNotaFiscal.dto.payment;
using GeradorNotaFiscal.interfaces.services;
using Microsoft.AspNetCore.Mvc;

namespace GeradorNotaFiscal.controllers
{
    [ApiController]
    [Route("api/pagamentos")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult getPayments()
        {
            var payments = _paymentService.getAllPayments();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public IActionResult getPaymentById(Guid id)
        {
            var payment = _paymentService.getPaymentById(id);
            return Ok(payment);
        }

        [HttpPost]
        public IActionResult createPayment([FromBody] PaymentCreateDto createPaymentDto)
        {
            var createdPayment = _paymentService.processPayment(createPaymentDto);
            return CreatedAtAction(
                nameof(getPaymentById), 
                new { id = createdPayment.Id }, 
                createdPayment
            );
        }

        [HttpPatch("{id}")]
        public IActionResult updatePayment(Guid id, [FromBody] PaymentUpdateDto updatePaymentDto)
        {
            var updatedPayment = _paymentService.updatePayment(id, updatePaymentDto);
            return Ok(updatedPayment);
        }

        [HttpPatch("cancel/{id}")]
        public IActionResult cancelPayment(Guid id)
        {
            var canceledPayment = _paymentService.cancelPayment(id);
            return Ok(canceledPayment);
        }
    }
}

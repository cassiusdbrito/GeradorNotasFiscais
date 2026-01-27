using GeradorNotaFiscal.dto.invoice;
using GeradorNotaFiscal.dto.payment;
using GeradorNotaFiscal.exceptions;
using GeradorNotaFiscal.interfaces.mappers;
using GeradorNotaFiscal.interfaces.repositories;
using GeradorNotaFiscal.interfaces.services;
using GeradorNotaFiscal.utils.enums;

namespace GeradorNotaFiscal.services
{
    public class PaymentService : IPaymentService
    {
        private readonly ILogger<PaymentService> _logger;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentMapper _paymentMapper;
        private readonly IInvoiceService _invoiceService;
        public PaymentService(ILogger<PaymentService> logger, IPaymentMapper paymentMapper, IPaymentRepository paymentRepository, IInvoiceService invoiceService)
        {
            _logger = logger;
            _paymentMapper = paymentMapper;
            _paymentRepository = paymentRepository;
            _invoiceService = invoiceService;
        }
        public async Task cancelPayment(Guid id)
        {
            var payment =  await _paymentRepository.getAsync(id);
            if (payment == null)
            {
                throw new NotFoundException("Pagamento não encontrado");
            }
            payment.status = PaymentStatusEnum.Canceled;
        }

        public async Task<InvoiceDto> generateInvoice(Guid paymentId)
        {
            var payment =  await _paymentRepository.getAsync(paymentId);
            if (payment == null)
            {
                throw new NotFoundException("Pagamento não encontrado, não foi possível gerar a nota fiscal");
            }
            var invoiceCreateDto = new InvoiceCreateDto
            {
                paymentId = paymentId,
                invoiceValue = payment.valuePaid
                
            };
            _logger.LogInformation("Gerando nota fiscal para o pagamento {PaymentId}", paymentId);
            var invoice = await _invoiceService.generateInvoice(invoiceCreateDto);
            _logger.LogInformation("Nota fiscal gerada com sucesso para o pagamento {PaymentId}", paymentId);
            return invoice;
        }

        public async Task<List<PaymentDto>> getAllPayments()
        {
            _logger.LogInformation("Buscando todos os pagamentos");
            var payments = await _paymentRepository.getAllAsync();
            return payments.Select(payment => _paymentMapper.toDto(payment)).ToList();
        }

        public async Task<PaymentDto> getPaymentById(Guid id)
        {
            _logger.LogInformation("Buscando pagamento pelo ID: {PaymentId}", id);
            var payment = await _paymentRepository.getAsync(id);
            return _paymentMapper.toDto(payment);
        }

        public async Task<PaymentDto> getPaymentByOrderId(Guid orderId)
        {
            _logger.LogInformation("Buscando pagamento pelo ID do pedido: {OrderId}", orderId);
            var payments = await _paymentRepository.getAllAsync();
            var payment = payments.FirstOrDefault(p => p.orderId == orderId);

            if (payment == null)
            {
                throw new NotFoundException("Pagamento não encontrado para o pedido informado");
            }

            return _paymentMapper.toDto(payment);
        }

        public async Task<PaymentDto> processPayment(PaymentCreateDto createPaymentDto)
        {
            var newPayment = await _paymentRepository.createAsync(_paymentMapper.toEntity(createPaymentDto));
            if (newPayment.status == PaymentStatusEnum.Paid)
            {
                await generateInvoice(newPayment.id);
            }
            return _paymentMapper.toDto(newPayment);
        }

        public async Task<PaymentDto> updatePayment(Guid id, PaymentUpdateDto updatePaymentDto)
        {
            var payment =  await _paymentRepository.getAsync(id);
            if (payment == null)
            {
                throw new NotFoundException("Pagamento não encontrado");
            }

            if (payment.status == PaymentStatusEnum.Canceled || updatePaymentDto == null)
            {
                throw new BadRequestException("Não foi possível atualizar o pagamento");
            }

            _logger.LogInformation("Atualizando pagamento com ID: {PaymentId}", id);

            if (updatePaymentDto.paymentDate.HasValue)
                payment.paymentDate = updatePaymentDto.paymentDate.Value;

            if (updatePaymentDto.paymentMethod.HasValue)
                payment.paymentMethod = updatePaymentDto.paymentMethod.Value;

            if (updatePaymentDto.status.HasValue)
                payment.status = updatePaymentDto.status.Value;


            var updatedPayment =  await _paymentRepository.updateAsync(payment);
            _logger.LogInformation("Pagamento com ID: {PaymentId} atualizado com sucesso", id);

            if (updatedPayment.status == PaymentStatusEnum.Paid)
            {
                await generateInvoice(updatedPayment.id);
            }

            return _paymentMapper.toDto(updatedPayment);
        }
    }
}

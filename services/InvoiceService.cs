using GeradorNotaFiscal.dto.invoice;
using GeradorNotaFiscal.exceptions;
using GeradorNotaFiscal.interfaces.mappers;
using GeradorNotaFiscal.interfaces.repositories;
using GeradorNotaFiscal.interfaces.services;

namespace GeradorNotaFiscal.services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ILogger<InvoiceService> _logger;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceMapper _invoiceMapper;
        public InvoiceService(ILogger<InvoiceService> logger, IInvoiceMapper mapper, IInvoiceRepository repository)
        {
            _logger = logger;
            _invoiceMapper = mapper;
            _invoiceRepository = repository;
        }
        public async Task deleteInvoiceById(Guid id)
        {
            _logger.LogInformation($"Deletando nota fiscal com id: {id}");
            await _invoiceRepository.deleteAsync(id);
        }

        public async Task<InvoiceDto> generateInvoice(InvoiceCreateDto createInvoiceDto)
        {
            try {
                _logger.LogInformation("Gerando nova nota fiscal");
                var newInvoice = await _invoiceRepository.saveAsync(_invoiceMapper.toEntity(createInvoiceDto));
                _logger.LogInformation($"Nota fiscal gerada com id: {newInvoice.id}");
                return _invoiceMapper.toDto(newInvoice);
            }
            catch (BadRequestException ex)
            {
                throw new BadRequestException($"Erro ao gerar nota fiscal: {ex.Message}");
            }

            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao gerar nota fiscal: {ex.Message}");
            }

        }

        public async Task<List<InvoiceDto>> getAllInvoices()
        {
            _logger.LogInformation("Buscando todas as notas fiscais");
            var invoices = await _invoiceRepository.getAllAsync();
            return invoices.Select(invoice => _invoiceMapper.toDto(invoice)).ToList();
        }

        public async Task<InvoiceDto> getInvoiceById(Guid id)
        {
            _logger.LogInformation($"Buscando nota fiscal com id: {id}");
            var invoice = await _invoiceRepository.getAsync(id);
            if (invoice == null)
            {
                throw new NotFoundException($"Nota fiscal com id {id} não encontrada.");
            }
            return _invoiceMapper.toDto(invoice);

        }

        public async Task<InvoiceDto> getInvoiceByPaymentId(Guid paymentId)
        {
            var invoices = await _invoiceRepository.getAllAsync();
            var invoice = invoices.FirstOrDefault(inv => inv.paymentId == paymentId);
            if (invoice == null)
            {
                throw new NotFoundException($"Nota fiscal com id de pagamento {paymentId} não encontrada.");
            }
            return _invoiceMapper.toDto(invoice);
        }
    }
}

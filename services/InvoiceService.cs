using GeradorNotaFiscal.dto.invoice;
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
            await _invoiceRepository.deleteAsync(id);
        }

        public async Task<InvoiceDto> generateInvoice(InvoiceCreateDto createInvoiceDto)
        {
            var newInvoice = await _invoiceRepository.saveAsync(_invoiceMapper.toEntity(createInvoiceDto));
            return _invoiceMapper.toDto(newInvoice);
        }

        public async Task<List<InvoiceDto>> getAllInvoices()
        {
            var invoices = await _invoiceRepository.getAllAsync();
            return invoices.Select(invoice => _invoiceMapper.toDto(invoice)).ToList();
        }

        public async Task<InvoiceDto> getInvoiceById(Guid id)
        {
            var invoice = await _invoiceRepository.getAsync(id);
            return _invoiceMapper.toDto(invoice);

        }

        public async Task<InvoiceDto> getInvoiceByPaymentId(Guid paymentId)
        {
            var invoices = await _invoiceRepository.getAllAsync();
            var invoice = invoices.FirstOrDefault(inv => inv.paymentId == paymentId);
            if (invoice == null)
            {
                throw new Exception($"Nota fiscal com id de pagamento {paymentId} não encontrada.");
            }
            return _invoiceMapper.toDto(invoice);
        }
    }
}

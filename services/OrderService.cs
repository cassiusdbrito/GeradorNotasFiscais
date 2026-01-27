using GeradorNotaFiscal.dto.order;
using GeradorNotaFiscal.exceptions;
using GeradorNotaFiscal.interfaces.mappers;
using GeradorNotaFiscal.interfaces.repositories;
using GeradorNotaFiscal.interfaces.services;

namespace GeradorNotaFiscal.services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderMapper _orderMapper;
        public OrderService(ILogger<OrderService> logger, IOrderMapper orderMapper, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderMapper = orderMapper;
            _orderRepository = orderRepository;
        }
        public async Task deleteOrder(Guid id)
        {
            _logger.LogInformation($"Deletando pedido com id: {id}");
            await _orderRepository.deleteAsync(id);
        }

        public async Task<List<OrderDto>> getAllOrders()
        {
            _logger.LogInformation("Buscando todos os pedidos");
            var orders = await _orderRepository.getAllAsync();
            return orders.Select(order => _orderMapper.toDto(order)).ToList();
        }

        public async Task<OrderDto> getOrderById(Guid id)
        {
            _logger.LogInformation($"Buscando pedido com id: {id}");
            var order = await _orderRepository.getAsync(id);

            if (order == null)
            {
                throw new NotFoundException("Pedido não encontrado");
            }

            return _orderMapper.toDto(order);
        }

        public async Task<OrderDto> processOrder(CreateOrderDto createOrderDto)
        {
            try {
                _logger.LogInformation("Processando novo pedido");
                var newOrder = await _orderRepository.createAsync(_orderMapper.toEntity(createOrderDto));
                _logger.LogInformation($"Pedido processado com sucesso. Id do pedido: {newOrder.id}");
                return _orderMapper.toDto(newOrder);
            }
            catch (BadRequestException ex)
            {
                throw new BadRequestException("Erro ao processar o pedido: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao processar o pedido: " + ex.Message);
            }
        }

        public async Task<OrderDto> updateOrder(Guid id, OrderUpdateDto updateOrderDto)
        {
            _logger.LogInformation($"Atualizando pedido com id: {id}");
            var order = await _orderRepository.getAsync(id);
            if (order == null)
            {
                throw new NotFoundException("Pedido não encontrado");
            }

            if (updateOrderDto.status == null)
            {

                throw new BadRequestException("Status do pedido é obrigatório");
            }

            order.status = updateOrderDto.status;
            var updatedOrder = await _orderRepository.updateAsync(order);

            _logger.LogInformation($"Pedido com id: {id} atualizado com sucesso");
            return _orderMapper.toDto(updatedOrder);
        }
    }
}

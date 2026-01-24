using GeradorNotaFiscal.dto.order;
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
            await _orderRepository.deleteAsync(id);
        }

        public async Task<List<OrderDto>> getAllOrders()
        {
            var orders = await _orderRepository.getAllAsync();
            return orders.Select(order => _orderMapper.toDto(order)).ToList();
        }

        public async Task<OrderDto> getOrderById(Guid id)
        {
            var order = await _orderRepository.getAsync(id);
            return _orderMapper.toDto(order);
        }

        public async Task<OrderDto> processOrder(CreateOrderDto createOrderDto)
        {
            var newOrder = await _orderRepository.createAsync(_orderMapper.toEntity(createOrderDto));
            return _orderMapper.toDto(newOrder);
        }

        public async Task<OrderDto> updateOrder(Guid id, OrderUpdateDto updateOrderDto)
        {
            var order = await _orderRepository.getAsync(id);
            if (order == null)
            {
                throw new Exception("Pedido não encontrado");
            }
            order.status = updateOrderDto.status;
            var updatedOrder = await _orderRepository.updateAsync(order);
            return _orderMapper.toDto(updatedOrder);
        }
    }
}

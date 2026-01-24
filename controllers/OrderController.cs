using GeradorNotaFiscal.dto.order;
using GeradorNotaFiscal.interfaces.services;
using Microsoft.AspNetCore.Mvc;

namespace GeradorNotaFiscal.controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService service)
        {
            _orderService = service;
        }

        [HttpGet]
        public IActionResult getOrders()
        {
            var orders = _orderService.getAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult getOrderById(Guid id)
        {
            var order = _orderService.getOrderById(id);
            return Ok(order);
        }

        [HttpPost]
        public IActionResult createOrder([FromBody] CreateOrderDto createOrderDto)
        {
            var createdOrder = _orderService.processOrder(createOrderDto);

            return CreatedAtAction(
                nameof(getOrderById), 
                new { id = createdOrder.Id }, 
                createdOrder
            );
        }

        [HttpPatch("{id}")]
        public IActionResult updateOrderStatus(Guid id, [FromBody] OrderUpdateDto updateOrderStatusDto)
        {
            var updatedOrder = _orderService.updateOrder(id, updateOrderStatusDto);
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteOrder(Guid id)
        {
            _orderService.deleteOrder(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrdering.API.DTOs;
using OnlineFoodOrdering.API.Services;

namespace OnlineFoodOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var order = await _orderService.CreateOrder(orderCreateDto);
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);

            if (order == null)
                return NotFound("Order not found");

            return Ok(order);
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var result = await _orderService.CancelOrder(id);

            if (result == false)
                return NotFound("Order not found");

            return Ok("Order cancelled successfully");
        }
    }
}
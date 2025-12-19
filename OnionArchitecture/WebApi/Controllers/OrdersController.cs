using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.DTOs;
using WebApi.Requests;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly OrderService _orderService;

        // Dependency Injection makes this possible
        public OrdersController(OrderService orderService, ILogger<OrdersController> logger)
        {

            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost("{id}/ship")]
        public async Task<IActionResult> ShipOrder(ShipOrderRequest request)
        {
            await _orderService.ShipOrderAsync(request.ToCommand());
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken ct)
        {
            var id = await _orderService.CreateOrderAsync(request.ToCommand(), ct);
            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }

        [HttpGet("Get/{id:guid}")]
        public async Task<IActionResult> Get(GetOrderRequest request)
        {
            var order = await _orderService.GetOrderAsync(request.ToQuery());
            return Ok(order);
        } 

    }
}

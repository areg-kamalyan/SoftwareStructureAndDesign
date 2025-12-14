using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Requests;

namespace Presentation.Controllers
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
        public async Task<IActionResult> ShipOrder(Guid id)
        {
            await _orderService.ShipOrderAsync(id);
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest req, CancellationToken ct)
        {
            var id = await _orderService.CreateOrderAsync(req, ct);
            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }

        [HttpGet("Get/{id:guid}")]
        public async Task<IActionResult> Get(Guid id) 
        {
            var order = await _orderService.GetOrderAsync(id);
            return Ok(order);
        } 

    }
}

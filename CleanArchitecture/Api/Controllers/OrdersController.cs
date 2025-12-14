using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly CreateOrderUseCase _createUseCase;
        private readonly ShipOrderHandler _shipOrderHandler;
        private readonly GetOrderUseCase _getOrderUseCase;

        // Dependency Injection makes this possible
        public OrdersController(ShipOrderHandler shipOrderHandler, CreateOrderUseCase createUseCase, GetOrderUseCase getOrderUseCase, ILogger<OrdersController> logger)
        {

            _logger = logger;
            _createUseCase = createUseCase;
            _getOrderUseCase = getOrderUseCase;
            _shipOrderHandler = shipOrderHandler;
        }

        [HttpPost("{id}/ship")]
        public async Task<IActionResult> ShipOrder(Guid id)
        {
            await _shipOrderHandler.Execute(id);
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest req, CancellationToken ct)
        {
            var id = await _createUseCase.ExecuteAsync(req, ct);
            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }

        [HttpGet("Get/{id:guid}")]
        public async Task<IActionResult> Get(Guid id) 
        {
            var order = await _getOrderUseCase.ExecuteAsync(id);
            return Ok(order);
        } 

    }
}

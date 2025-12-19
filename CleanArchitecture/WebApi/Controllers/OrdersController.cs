using Application.DTOs;
using Application.Interfaces.UseCases;
using Application.UseCases.Orders.CreateOrder;
using Application.UseCases.Orders.GetOrder;
using Application.UseCases.Orders.ShipOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Requests;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly ICreateOrderUseCase _createUseCase;
        private readonly IShipOrderUseCase _shipOrderUseCase;
        private readonly IGetOrderUseCase _getOrderUseCase;

        // Dependency Injection makes this possible
        public OrdersController(IShipOrderUseCase shipOrderUseCase, ICreateOrderUseCase createUseCase, IGetOrderUseCase getOrderUseCase, ILogger<OrdersController> logger)
        {

            _logger = logger;
            _createUseCase = createUseCase;
            _getOrderUseCase = getOrderUseCase;
            _shipOrderUseCase = shipOrderUseCase;
        }

        [HttpPost("{id}/ship")]
        public async Task<IActionResult> ShipOrder(ShipOrderRequest request)
        {
            await _shipOrderUseCase.ExecuteAsync(request.ToCommand());
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken ct)
        {
            var id = await _createUseCase.ExecuteAsync(request.ToCommand(), ct);
            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }

        [HttpGet("Get/{id:guid}")]
        public async Task<IActionResult> Get(GetOrderRequest request)
        {
            var order = await _getOrderUseCase.ExecuteAsync(request.ToQuery());
            return Ok(order);
        }

    }
}

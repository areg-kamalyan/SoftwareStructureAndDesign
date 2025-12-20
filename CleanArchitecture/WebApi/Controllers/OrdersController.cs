using Application.Interfaces.UseCases;
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

        [HttpPost("{orderNumber}/ship")]
        public async Task<IActionResult> ShipOrder(string orderNumber)
        {
            await _shipOrderUseCase.ExecuteAsync(orderNumber);
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken ct)
        {
            var orderNumber = await _createUseCase.ExecuteAsync(request.ToCommand(), ct);
            return Ok(orderNumber);
        }

        [HttpGet("Get/{orderNumber:guid}")]
        public async Task<IActionResult> Get(string orderNumber)
        {
            var order = await _getOrderUseCase.ExecuteAsync(orderNumber);
            return Ok(order);
        }

    }
}

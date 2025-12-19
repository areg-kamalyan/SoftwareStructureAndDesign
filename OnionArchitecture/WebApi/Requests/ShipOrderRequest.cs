using Services.Commands;

namespace WebApi.Requests
{
    public class ShipOrderRequest
    {
        public Guid OrderId { get; set; }

        public ShipOrderCommand ToCommand()
            => new ShipOrderCommand(OrderId);
    }
}

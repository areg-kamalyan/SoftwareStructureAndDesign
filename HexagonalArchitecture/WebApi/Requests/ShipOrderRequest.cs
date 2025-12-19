using Application.UseCases.Orders.ShipOrder;

namespace WebApi.Requests
{
    public class ShipOrderRequest
    {
        public Guid OrderId { get; set; }

        public ShipOrderCommand ToCommand()
            => new ShipOrderCommand(OrderId);
    }
}

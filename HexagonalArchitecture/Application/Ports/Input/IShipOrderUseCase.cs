using Application.UseCases.Orders.ShipOrder;

namespace Application.Ports.Input
{
    public interface IShipOrderUseCase
    {
        Task ExecuteAsync(ShipOrderCommand command);
    }
}

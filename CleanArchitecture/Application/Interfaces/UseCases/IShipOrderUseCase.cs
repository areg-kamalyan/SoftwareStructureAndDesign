using Application.UseCases.Orders.ShipOrder;

namespace Application.Interfaces.UseCases
{
    public interface IShipOrderUseCase
    {
        Task ExecuteAsync(ShipOrderCommand command);
    }
}

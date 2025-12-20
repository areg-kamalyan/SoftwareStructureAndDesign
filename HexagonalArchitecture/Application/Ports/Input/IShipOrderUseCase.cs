namespace Application.Ports.Input
{
    public interface IShipOrderUseCase
    {
        Task ExecuteAsync(string orderNumber);
    }
}

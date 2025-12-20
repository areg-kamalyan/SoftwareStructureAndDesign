namespace Application.Interfaces.UseCases
{
    public interface IShipOrderUseCase
    {
        Task ExecuteAsync(string orderNumber);
    }
}

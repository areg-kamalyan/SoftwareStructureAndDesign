using Domain.Entities;
namespace Application.Ports.Input
{
    public interface IGetOrderUseCase
    {
        Task<Order> ExecuteAsync(string orderNumber);
    }

}
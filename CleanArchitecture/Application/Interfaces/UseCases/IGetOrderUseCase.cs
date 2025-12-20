using Domain.Entities;
namespace Application.Interfaces.UseCases
{
    public interface IGetOrderUseCase
    {
        Task<Order> ExecuteAsync(string orderNumber);
    }

}
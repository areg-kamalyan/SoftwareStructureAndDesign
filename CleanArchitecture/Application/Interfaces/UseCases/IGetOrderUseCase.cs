using Application.UseCases.Orders.GetOrder;
using Domain.Entities;
namespace Application.Interfaces.UseCases
{
    public interface IGetOrderUseCase
    {
        Task<Order> ExecuteAsync(GetOrderQuery query);
    }

}
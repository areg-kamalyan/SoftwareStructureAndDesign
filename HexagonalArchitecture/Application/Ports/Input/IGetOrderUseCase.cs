using Application.DTOs;
using Application.UseCases.Orders.GetOrder;
using Domain.Entities;
namespace Application.Ports.Input
{
    public interface IGetOrderUseCase
    {
        Task<Order> ExecuteAsync(GetOrderQuery query);
    }

}
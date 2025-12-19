using Domain.ValueObjects;

namespace Application.UseCases.Orders.CreateOrder
{
    public record CreateOrderCommand(Guid UserId, string Title, string Details, Money Price);
}

using Domain.ValueObjects;

namespace Services.Requests
{
    public record CreateOrderRequest(Guid UsersId, string Title, string Details, Money Price);
}

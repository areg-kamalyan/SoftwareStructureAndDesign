using Domain.ValueObjects;

namespace Services.Commands
{
    public record CreateOrderCommand(Guid UserId, string Title, string Details, Money Price);
}

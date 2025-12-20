
using Domain.ValueObjects;

namespace Services.DTOs
{
    public record OrderDto(Guid UserId, string Title, string Details, Money Price);
}

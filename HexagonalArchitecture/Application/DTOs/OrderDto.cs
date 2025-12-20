
using Domain.ValueObjects;

namespace Application.DTOs
{
    public record OrderDto(Guid UserId, string Title, string Details, Money Price);
}

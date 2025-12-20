using Domain.ValueObjects;
using Services.DTOs;

namespace WebApi.Requests
{
    public class CreateOrderRequest
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public Money Price { get; set; }

        public OrderDto ToCommand()
            => new OrderDto(UserId, Title, Details, Price);
    }
}

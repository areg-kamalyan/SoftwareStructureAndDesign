using Application.UseCases.Orders.CreateOrder;
using Domain.ValueObjects;

namespace WebApi.Requests
{
    public class CreateOrderRequest
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public Money Price { get; set; }

        public CreateOrderCommand ToCommand()
            => new CreateOrderCommand(UserId, Title, Details, Price);
    }
}

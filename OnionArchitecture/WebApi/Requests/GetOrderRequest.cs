using Services.Querys;

namespace WebApi.Requests
{
    public class GetOrderRequest
    {
        public Guid UserId { get; set; }

        public GetOrderQuery ToQuery()
            => new GetOrderQuery(UserId);
    }
}

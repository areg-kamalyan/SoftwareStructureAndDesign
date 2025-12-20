using Domain.Entities;

namespace Services.Interfaces
{
    public interface IOrderShippedEventPublisher
    {
        void Publish(Order order);
    }
}

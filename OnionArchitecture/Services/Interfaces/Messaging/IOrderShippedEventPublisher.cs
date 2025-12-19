using Domain.Entities;

namespace Services.Interfaces.Messaging
{
    public interface IOrderShippedEventPublisher
    {
        void Publish(Order order);
    }
}

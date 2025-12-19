using Domain.Entities;

namespace Application.Interfaces.Messaging
{
    public interface IOrderShippedEventPublisher
    {
        void Publish(Order order);
    }
}

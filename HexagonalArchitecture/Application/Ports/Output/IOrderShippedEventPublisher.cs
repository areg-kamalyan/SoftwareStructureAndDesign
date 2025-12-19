using Domain.Entities;

namespace Application.Ports.Output
{
    public interface IOrderShippedEventPublisher
    {
        void Publish(Order order);
    }
}

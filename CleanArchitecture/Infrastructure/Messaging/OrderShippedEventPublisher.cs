using Application.Interfaces.Messaging;
using Domain.Entities;
namespace Infrastructure.Messaging
{
    public class OrderShippedEventPublisher : IOrderShippedEventPublisher
    {
        public void Publish(Order order)
        {
            // In real life: message bus, Kafka, RabbitMQ, etc.
            Console.WriteLine($"Order {order.Number} shipped event published");
        }
    }
}

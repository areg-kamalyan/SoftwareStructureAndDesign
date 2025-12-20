using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrderShippingPolicy
    {
        bool CanShip(Order order);
    }
}

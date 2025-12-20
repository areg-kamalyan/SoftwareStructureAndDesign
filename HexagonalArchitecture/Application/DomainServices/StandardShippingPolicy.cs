using Domain.Entities;
using Domain.Interfaces;

namespace Application.DomainServices
{
    internal class StandardShippingPolicy : IOrderShippingPolicy
    {
        public bool CanShip(Order order)
        {
            return true;
        }
    }
}

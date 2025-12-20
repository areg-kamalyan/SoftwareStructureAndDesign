using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPricingPolicy
    {
        decimal CalculateTotal(Order order);
    }
}

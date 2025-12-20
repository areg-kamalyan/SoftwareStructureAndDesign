using Domain.Entities;
using Domain.Interfaces;

namespace Services.DomainServices
{
    internal class StandardPricingPolicy : IPricingPolicy
    {
        public decimal CalculateTotal(Order order)
        {
            decimal shippingPrice = 30;
            return order.Price.Amount + shippingPrice;
        }
    }
}

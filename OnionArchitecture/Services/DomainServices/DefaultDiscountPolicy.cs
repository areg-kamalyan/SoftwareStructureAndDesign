using Domain.Interfaces;


namespace Services.DomainServices
{
    public class DefaultDiscountPolicy : IDiscountPolicy
    {
        public decimal ApplyDiscount(decimal amount)
            => amount > 100 ? amount * 0.9m : amount;
    }
}

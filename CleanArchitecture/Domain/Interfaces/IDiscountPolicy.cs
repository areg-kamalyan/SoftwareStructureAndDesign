namespace Domain.Interfaces
{
    public interface IDiscountPolicy
    {
        decimal ApplyDiscount(decimal amount);
    }
}

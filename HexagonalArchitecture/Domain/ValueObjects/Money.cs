
namespace Domain.ValueObjects
{
    public sealed record Money
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "USD";

        public Money() { }

        public Money(decimal amount, string currency = "USD")
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));

            Amount = amount;
            Currency = currency;
        }
    }
}

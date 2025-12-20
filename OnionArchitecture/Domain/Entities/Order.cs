using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities
{
    // Domain/Entities/Order.cs
    public class Order
    {
        public string Title { get; private set; } = string.Empty;
        public string Details { get; private set; } = string.Empty;
        public string Number { get; private set; }
        public DateTime Date { get; private set; }
        public OrderStatus Status { get; private set; }
        public Money Price { get; private set; }
        public Guid UsersId { get; private set; }
        public Money Total { get; private set; }
        private Order() { }
        public Order(string orderNumber, Guid usersId, string title, string details, Money price)
        {
            Number = orderNumber;
            Date = DateTime.Now;
            UsersId = usersId;
            Title = title;
            Details = details;
            Price = price;
            Status = OrderStatus.Created;
        }


        public void CalculateTotal(IPricingPolicy pricing, IDiscountPolicy discount, ITaxCalculator tax)
        {
            var subtotal = pricing.CalculateTotal(this);
            var discounted = discount.ApplyDiscount(subtotal);
            Total = new Money() { Amount = discounted + tax.CalculateTax(discounted), Currency = "Usd" };
        }

        // Domain behavior methods enforce business rules
        public void MarkAsShipped()
        {
            if (Status == OrderStatus.Pending)
            {
                Status = OrderStatus.Shipped;
            }
            else
            {
                throw new InvalidOperationException("Only pending orders can be shipped.");
            }
        }
    }
}

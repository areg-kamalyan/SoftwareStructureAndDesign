using Domain.ValueObjects;

namespace Domain.Entities
{
    // Domain/Entities/Order.cs
    public class Order
    {
        public string Title { get; private set; }
        public string Details { get; private set; }
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Status { get; private set; }
        public Money Price { get; private set; }
        public Guid UsersId { get; private set; }
        private Order() { }
        public Order(Guid usersId, string title, string details, Money price)
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            UsersId = usersId;
            Title = title;
            Details = details;
            Price = price;
            Status = "Pending";
        }

        // Domain behavior methods enforce business rules
        public void MarkAsShipped()
        {
            if (Status == "Pending")
            {
                Status = "Shipped";
            }
            else
            {
                throw new InvalidOperationException("Only pending orders can be shipped.");
            }
        }
    }
}

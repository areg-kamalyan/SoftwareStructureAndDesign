using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.Price, money =>
            {
                money.Property(m => m.Amount)
                     .HasColumnName("PriceAmount");

                money.Property(m => m.Currency)
                     .HasColumnName("PriceCurrency");
            });
        }
    }
}

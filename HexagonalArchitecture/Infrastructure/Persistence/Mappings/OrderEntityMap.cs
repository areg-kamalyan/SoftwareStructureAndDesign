using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Mappings
{
    public class OrderEntityMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //builder.HasKey(o => o.Id);
            //builder.Property(o => o.Status)
            //.HasConversion<string>();

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

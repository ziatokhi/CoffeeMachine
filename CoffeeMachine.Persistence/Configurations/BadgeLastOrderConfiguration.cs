using CoffeeMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeMachine.Persistence.Configurations
{
    public class BadgeLastOrderConfiguration : IEntityTypeConfiguration<BadgeLastOrder>
    {
        public void Configure(EntityTypeBuilder<BadgeLastOrder> builder)
        {
            // builder.Property(e => e.BadgeLastOrderId).HasColumnName("BadgeLastOrderID");
            builder.HasKey(e => e.BadgeLastOrderId);
            builder.Property(e => e.OrderId)
                .IsRequired();
            builder.Property(e => e.BadgeNo)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(e => e.Order)
                .WithOne(e => e.BadgeLastOrder)
             .HasConstraintName("FK_BadgeLastOrder_Order");
        }
    }
}
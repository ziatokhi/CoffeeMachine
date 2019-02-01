using CoffeeMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeMachine.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.OrderId);

            builder.Property(e => e.OrderId)
                .HasColumnName("OrderID");

            builder.Property(e => e.SugarLevel).IsRequired();
            builder.Property(e => e.IsOwnMug).IsRequired();
            builder.Property(e => e.DrinkTypeId).IsRequired();
            builder.Property(e => e.OrderDate).HasColumnType("datetime");

            builder.HasOne(e => e.DrinkType)
                .WithMany(e => e.Order)
                .HasForeignKey(e => e.DrinkTypeId)
             .HasConstraintName("FK_Order_DrinkType");
        }
    }
}
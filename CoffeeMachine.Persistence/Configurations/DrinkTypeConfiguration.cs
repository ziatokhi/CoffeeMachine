using CoffeeMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeMachine.Persistence.Configurations
{
    public class DrinkTypeConfiguration : IEntityTypeConfiguration<DrinkType>
    {
        public void Configure(EntityTypeBuilder<DrinkType> builder)
        {
            builder.Property(e => e.DrinkTypeId).HasColumnName("DrinkTypeID");

            builder.Property(e => e.DrinkTypeName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Description).HasColumnType("ntext");
            builder.Property(e => e.PictureUrl).HasColumnType("ntext");

            builder.HasMany(e => e.Order)
                .WithOne(e => e.DrinkType)
                .HasForeignKey(e => e.DrinkTypeId)
                .HasConstraintName("FK_DrinkType_Order");
        }
    }
}
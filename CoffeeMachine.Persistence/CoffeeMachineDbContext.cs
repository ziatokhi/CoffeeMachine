

using CoffeeMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Persistence
{
    public class CoffeeMachineDbContext : DbContext
    {
        public CoffeeMachineDbContext(DbContextOptions<CoffeeMachineDbContext> options)
            : base(options)
        {
        }

        public DbSet<DrinkType> DrinkType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<BadgeLastOrder> BadgeLastOrder { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoffeeMachineDbContext).Assembly);
        }

    }
}
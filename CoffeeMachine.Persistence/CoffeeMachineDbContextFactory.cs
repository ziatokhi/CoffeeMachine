

using CoffeeMachine.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Persistence
{
    class CoffeeMachineDbContextFactory : DesignTimeDbContextFactoryBase<CoffeeMachineDbContext>
    {
       

        protected override CoffeeMachineDbContext CreateNewInstance(DbContextOptions<CoffeeMachineDbContext> options)
        {
            return new  CoffeeMachineDbContext(options);
        }
    }
}

using CoffeeMachine.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMachine.Domain.Entities
{
    public class GetDrinkTypeAllQuery
    {
        private readonly CoffeeMachineDbContext _context;

        public GetDrinkTypeAllQuery(CoffeeMachineDbContext context)
        {
            _context = context;
        }

        public Task<List<DrinkType>> Handle(CancellationToken cancellationToken)
        {
            return _context.DrinkType
                .ToListAsync(cancellationToken);
        }
    }
}
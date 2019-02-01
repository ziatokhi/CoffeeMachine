using CoffeeMachine.Application.BadgeLastOrders.Commands;
using CoffeeMachine.Application.BadgeLastOrders.Queries;
using CoffeeMachine.Application.Test.Infrastructure;
using CoffeeMachine.Persistence;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.Application.Test.BadgeLastOrders.Queries
{
    public class GetBadgeLastOrderQueryTest
    {
        //[Collection("QueryCollection")]

        private readonly CoffeeMachineDbContext _context;

        public GetBadgeLastOrderQueryTest()
        {
            _context = CoffeeMachineContextFactory.Create();
        }

        [Fact]
        public async Task GetTest()
        {
            var rtn = new GetBadgeLastOrderQuery(_context);

            var result = await rtn.GetAsync("123");

            result.ShouldBeOfType<BadgeLastOrderPreviewModel>();

            result.DrinkTypeModelPreview.Count.ShouldBe(3);
        }

        [Fact]
        public async Task SaveTest()
        {
            var rtn = new GetBadgeLastOrderQuery(_context);

            var result = await rtn.GetAsync("125");

            var cmd = new CreateOrderBadgeLastOrderCommand(_context);
            var cmdResult = await cmd.SaveAsync(result);

            cmdResult.ShouldBe(2);
        }
    }
}
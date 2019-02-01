using CoffeeMachine.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.Application.BadgeLastOrders.Queries
{
    public class GetBadgeLastOrderQuery
    {
        private readonly CoffeeMachineDbContext _context;

        public GetBadgeLastOrderQuery(CoffeeMachineDbContext context)
        {
            _context = context;
        }

        public async Task<BadgeLastOrderPreviewModel> GetAsync(string _BadgeNo)
        {
            // if (string.IsNullOrWhiteSpace(BadgeNo))
            var LastBadgeOrderData = await _context.BadgeLastOrder
                  .Include(e => e.Order)
                  .Where(e => e.BadgeNo == _BadgeNo)
                  .Select(e => e.Order)
                  .FirstOrDefaultAsync();

            //First Time
            if (LastBadgeOrderData == null)
            {
                List<DrinkTypeModelPreview> _DrinkTypeModelPreview = await _context.DrinkType
                              .Select(e => new DrinkTypeModelPreview { DrinkType = e, IsSelected = false }).ToListAsync();

                var _model = new BadgeLastOrderPreviewModel
                {
                    DrinkTypeModelPreview = _DrinkTypeModelPreview,
                };

                return _model;
            }
            else
            {
                List<DrinkTypeModelPreview> _DrinkTypeModelPreview = await _context.DrinkType
                    .Select(e => new DrinkTypeModelPreview { DrinkType = e, IsSelected = LastBadgeOrderData.DrinkTypeId==e.DrinkTypeId }).ToListAsync();

                var _model = new BadgeLastOrderPreviewModel
                {
                    DrinkTypeModelPreview = _DrinkTypeModelPreview,
                    IsOwnMug = LastBadgeOrderData.IsOwnMug,
                    SugarLevel = LastBadgeOrderData.SugarLevel,
                    BadgeNo = _BadgeNo,
                    DrinkTypeId = LastBadgeOrderData.DrinkTypeId
                };

                return _model;
            }
        }
    }
}
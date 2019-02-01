using CoffeeMachine.Application.BadgeLastOrders.Queries;
using CoffeeMachine.Domain.Entities;
using CoffeeMachine.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.Application.BadgeLastOrders.Commands
{
    public class CreateOrderBadgeLastOrderCommand
    {
        private readonly CoffeeMachineDbContext _context;

        public CreateOrderBadgeLastOrderCommand(CoffeeMachineDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync(BadgeLastOrderPreviewModel _BadgeLastOrderPreviewModel)
        {
            Order _Order = new Order
            {
                // OrderId = _OrderId,
                //Only Selected One from Array
                DrinkTypeId = _BadgeLastOrderPreviewModel.DrinkTypeId,

                IsOwnMug = _BadgeLastOrderPreviewModel.IsOwnMug,
                OrderDate = DateTime.Now,
                SugarLevel = _BadgeLastOrderPreviewModel.SugarLevel,
                BadgeLastOrder = null,
                DrinkType = null,
            };

            _context.Order.Add(_Order);

            //Update Badge Last Setting if Exist
            BadgeLastOrder _BadgeLastOrder = _context.BadgeLastOrder.Where(e => e.BadgeNo == _BadgeLastOrderPreviewModel.BadgeNo).FirstOrDefault();

            if (_BadgeLastOrder == null)
            {
                _BadgeLastOrder = new BadgeLastOrder
                {
                    BadgeNo = _BadgeLastOrderPreviewModel.BadgeNo,
                    OrderId = _Order.OrderId,
                    Order = null
                };
                _context.BadgeLastOrder.Add(_BadgeLastOrder);
            }
            else
            {
                _BadgeLastOrder.OrderId = _Order.OrderId;
                _context.Entry(_BadgeLastOrder).State = EntityState.Modified;
            }

            return await _context.SaveChangesAsync();
        }
    }
}
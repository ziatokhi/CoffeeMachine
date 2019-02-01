using CoffeeMachine.Domain.Entities;

namespace CoffeeMachine.Application.BadgeLastOrders.Queries
{
    public class DrinkTypeModelPreview
    {
        public DrinkType DrinkType { get; set; }
        public bool IsSelected { get; set; }
    }
}
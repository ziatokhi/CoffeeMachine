using System;

namespace CoffeeMachine.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int DrinkTypeId { get; set; }

        public int SugarLevel { get; set; }

        public bool IsOwnMug { get; set; }

        public DateTime? OrderDate { get; set; }
        public DrinkType DrinkType { get; set; }
        public BadgeLastOrder BadgeLastOrder { get; set; }
    }
}
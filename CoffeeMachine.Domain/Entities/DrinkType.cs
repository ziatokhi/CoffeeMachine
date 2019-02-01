using System.Collections.Generic;

namespace CoffeeMachine.Domain.Entities
{
    public class DrinkType
    {
        public int DrinkTypeId { get; set; }
        public string DrinkTypeName { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

        public ICollection<Order> Order { get; private set; }
    }
}
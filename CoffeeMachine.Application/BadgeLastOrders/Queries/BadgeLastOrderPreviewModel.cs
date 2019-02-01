using System.Collections.Generic;

namespace CoffeeMachine.Application.BadgeLastOrders.Queries
{
    public class BadgeLastOrderPreviewModel
    {
        public List<DrinkTypeModelPreview> DrinkTypeModelPreview { get; set; }

        public int SugarLevel { get; set; }

        public bool IsOwnMug { get; set; }

        public string BadgeNo { get; set; }
        public int DrinkTypeId { get; set; }

        // public Boolean IsEnable { get; set; }
    }
}
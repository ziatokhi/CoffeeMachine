namespace CoffeeMachine.Domain.Entities
{
    public class BadgeLastOrder
    {
        public int BadgeLastOrderId { get; set; }
        public int OrderId { get; set; }

        public string BadgeNo { get; set; }

        public Order Order { get; set; }
    }
}
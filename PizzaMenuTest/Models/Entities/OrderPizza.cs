namespace PizzaMenuTest.Models.Entities
{
    public class OrderPizza
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set;}

        public Order Order { get; set; }
        public Pizza Pizza { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PizzaMenuTest.Models.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? WorkerId {get; set;}
        public string Adress { get; set; }
        public OrerStatus Status { get; set; } = 0;
        public List<OrderPizza>? Pizzas { get; set; }
        public decimal Price {  get; set; }

        public Customer Customer { get; set; }
        public Worker Worker { get; set; }
    }
}

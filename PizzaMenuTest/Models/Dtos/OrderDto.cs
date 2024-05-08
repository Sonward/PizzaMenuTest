using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? WorkerId { get; set; }
        public string Adress { get; set; }
        public OrerStatus Status { get; set; }
        public List<OrderPizzaDto> Pizzas { get; set; }
        public decimal Price { get; set; }
    }
}

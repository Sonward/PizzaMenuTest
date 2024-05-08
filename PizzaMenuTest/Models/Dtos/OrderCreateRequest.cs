namespace PizzaMenuTest.Models.Dtos
{
    public class OrderCreateRequest
    {
        public int CustomerId { get; set; }
        public int? WorkerId { get; set; }
        public string Adress { get; set; }
        public List<int> PizzasIds { get; set; }
    }
}

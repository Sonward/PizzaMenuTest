namespace PizzaMenuTest.Models.Dtos
{
    public class OrderPizzaDto
    {
        public int OrerId { get; set; }
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }
    }
}

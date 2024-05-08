using System.ComponentModel.DataAnnotations;

namespace PizzaMenuTest.Models.Entities
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PizzaIngridient>? Ingridients { get; set; }
        public decimal Price { get; set; }

        //public List<Order> Orders { get; set; }

    }
}

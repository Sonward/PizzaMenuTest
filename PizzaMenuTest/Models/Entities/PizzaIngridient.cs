using System.ComponentModel.DataAnnotations;

namespace PizzaMenuTest.Models.Entities
{
    public class PizzaIngridient
    {
        //[Key]
        //public int Id { get; set; }
        public int PizzaId { get; set;}
        public int IngridientId { get; set; }

        public Pizza Pizza { get; set; }
        public Ingridient Ingridient { get; set; }
    }
}

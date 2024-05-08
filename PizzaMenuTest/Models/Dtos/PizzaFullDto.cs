using PizzaMenuTest.Models.Entities;
using PizzaMenuTest.Models.Dtos;

namespace PizzaMenuTest.Models.Dtos
{
    public class PizzaFullDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngridientDto> Ingridients { get; set; }
        public decimal Price { get; set; }
    }
}

using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Dtos
{
    public class PizzaCreateRequest
    {
        public string Name { get; set; }
        public List<int> Ingridients { get; set; } // get a list of ingridient's ids in current pizza
    }
}

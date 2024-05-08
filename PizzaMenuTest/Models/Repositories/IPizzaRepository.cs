using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories
{
    public interface IPizzaRepository
    {
        public ICollection<Pizza> GetAll();
        public Pizza GetById(int id);
        public bool Delete(int id);
        public Pizza Create(Pizza pizza);
        public Pizza Update(Pizza pizza);

        public void CalculatePrice(int pizzaId);
    }
}

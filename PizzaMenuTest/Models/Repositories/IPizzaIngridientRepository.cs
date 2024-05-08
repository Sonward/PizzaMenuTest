using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories
{
    public interface IPizzaIngridientRepository
    {
        public IEnumerable<PizzaIngridient> GetAll();
        public IEnumerable<PizzaIngridient> GetByPizzaId(int id);
        public IEnumerable<PizzaIngridient> GetByIngriddientId(int id);
        public bool Delete(PizzaIngridient ingridient);
        public HashSet<int> DeleteByPizzaId(int id);
        public HashSet<int> DeleteByIngridientId(int id);
        public PizzaIngridient Create (PizzaIngridient ingridient);
        public bool CreateRange(IEnumerable<PizzaIngridient> pizzaIngridients);
    }
}

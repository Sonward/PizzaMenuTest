using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories
{
    public interface IIngridientRepository
    {
        public ICollection<Ingridient> GetAll();
        public Ingridient GetById(int id);
        public bool Delete(int id);
        public Ingridient Create(Ingridient ingridient);
        public Ingridient Update(Ingridient ingridient);
    }
}

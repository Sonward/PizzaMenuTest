using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories
{
    public interface IWorkerRepository
    {
        public ICollection<Worker> GetAll();
        public Worker GetById(int id);
        public bool Delete(int id);
        public Worker Create(Worker worker);
        public Worker Update(Worker worker);
    }
}

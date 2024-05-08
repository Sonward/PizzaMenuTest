using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Services
{
    public interface IPizzaService
    {
        // CRUD
        public ICollection<PizzaDto> GetAll();
        public PizzaFullDto GetById(int id);
        public bool Delete(int id);
        public PizzaFullDto Create(PizzaCreateRequest request);
        public PizzaFullDto Update(PizzaFullDto pizza);

        public void CalculatePrice(int pizzaId);

    }
}

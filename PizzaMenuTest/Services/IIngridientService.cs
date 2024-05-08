using PizzaMenuTest.Models.Dtos;

namespace PizzaMenuTest.Services
{
    public interface IIngridientService
    {
        public ICollection<IngridientDto> GetAll();
        public IngridientDto GetById(int id);
        public bool Delete(int id);
        public IngridientDto Create(IngridientCreateRequest ingridient);
        public IngridientDto Update(IngridientDto ingridient);
    }
}

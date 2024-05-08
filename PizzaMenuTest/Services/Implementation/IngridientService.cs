using AutoMapper;
using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Models.Entities;
using PizzaMenuTest.Models.Repositories;

namespace PizzaMenuTest.Services.Implementation
{
    public class IngridientService(IIngridientRepository ingridientRepository,
        IPizzaIngridientRepository pizzaIngridientRepository,
        IPizzaService pizzaService,
        IMapper mapper) : IIngridientService
    {
        public ICollection<IngridientDto> GetAll()
        {
            return ingridientRepository.GetAll().Select(mapper.Map<IngridientDto>).ToList();
        }

        public IngridientDto GetById(int id)
        {
            return mapper.Map<IngridientDto>(ingridientRepository.GetById(id));
        }

        public bool Delete(int id)
        {
            var pizzaIds = pizzaIngridientRepository.GetByIngriddientId(id).Select(pi=>pi.PizzaId);
            bool result = ingridientRepository.Delete(id);

            if (result) 
            {
                foreach(var p in pizzaIds) {
                    pizzaIngridientRepository.Delete(new PizzaIngridient()
                    {
                        IngridientId = id,
                        PizzaId = p
                    });
                }
            }
            else { return result; }

            foreach (var pId in pizzaIds) { pizzaService.CalculatePrice(pId); }
            return result;
        }

        public IngridientDto Create(IngridientCreateRequest request)
        {
            var result = ingridientRepository.Create(mapper.Map<Ingridient>(request));
            return mapper.Map<IngridientDto>(result);
        }

        public IngridientDto Update(IngridientDto request)
        {
            var pizzaIds = pizzaIngridientRepository.GetByIngriddientId(request.Id).Select(pi => pi.PizzaId);
            var result = ingridientRepository.Update(mapper.Map<Ingridient>(request));
            foreach (var pId in pizzaIds) { pizzaService.CalculatePrice(pId); }
            return mapper.Map<IngridientDto>(result);
        }
    }
}

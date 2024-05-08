using AutoMapper;
using PizzaMenuTest.Models.Entities;
using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Models.Repositories;
using PizzaMenuTest.Migrations;
using PizzaMenuTest.Models.Repositories.Implementation;
using Azure.Core;

namespace PizzaMenuTest.Services.Implementation
{
    public class PizzaService(IPizzaRepository pizzaRepository, 
        IPizzaIngridientRepository pizzaIngridientRepository,
        IOrderService orderService,
        IOrderPizzaRepository orderPizzaRepository,
        IMapper mapper) : IPizzaService
    {
        public ICollection<PizzaDto> GetAll()
        {
            return pizzaRepository.GetAll().Select(mapper.Map<PizzaDto>).ToList();
        }

        public PizzaFullDto GetById(int id)
        {
            return mapper.Map<Pizza, PizzaFullDto>(pizzaRepository.GetById(id));
        }

        public bool Delete(int id)
        {
            var ordersIds = orderPizzaRepository.GetByPizzaId(id).Select(pi => pi.OrderId);
            bool result = pizzaRepository.Delete(id);

            if (result)
            {
                foreach (var o in ordersIds)
                {
                    orderPizzaRepository.Delete(new OrderPizza()
                    {
                        OrderId = id,
                        PizzaId = o
                    });
                }
            }
            else { return result; }

            foreach (var oId in ordersIds) { orderService.CalculatePrice(oId); }
            return result;
        }

        public PizzaFullDto Create(PizzaCreateRequest request)
        {
            var pizza = mapper.Map<PizzaCreateRequest, Pizza>(request);
            var result = pizzaRepository.Create(pizza);
            return mapper.Map<Pizza, PizzaFullDto>(result);
        }
        
        public PizzaFullDto Update(PizzaFullDto request) // don't like this realization, can have plenty of bugs
        {
            var pizza = mapper.Map<Pizza>(request);
            //var orersIds = orderPizzaRepository.GetByPizzaId(request.Id).Select(op => op.OrderId);
            var result = pizzaRepository.Update(pizza);

            var currentIngriients = pizzaIngridientRepository.GetByPizzaId(pizza.Id);
            var toAdd = pizza.Ingridients.Where(ing1 => !currentIngriients.Any(ing2 => ing2.IngridientId == ing1.IngridientId));
            var toRemove = currentIngriients.Where(ing1 => !pizza.Ingridients.Any(ing2 => ing2.IngridientId == ing1.IngridientId));
            pizzaIngridientRepository.CreateRange(toAdd);
            foreach (var ing in toRemove)
            {
                pizzaIngridientRepository.Delete(ing);
            }

            //foreach (var oId in orersIds) { orderService.CalculatePrice(oId); }
            CalculatePrice(result.Id);  
            result.Ingridients = pizzaRepository.GetById(result.Id).Ingridients;
            return mapper.Map<PizzaFullDto>(result);
        }

        public void CalculatePrice(int pizzaId)
        {
            pizzaRepository.CalculatePrice(pizzaId);
            var orersIds = orderPizzaRepository.GetByPizzaId(pizzaId).Select(op => op.OrderId);
            foreach (var oId in orersIds) { orderService.CalculatePrice(oId); }
        }
    }
}

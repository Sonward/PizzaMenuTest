using Microsoft.EntityFrameworkCore;
using PizzaMenuTest.Models.Entities;
using PizzaMenuTest.Exceptions;
using PizzaMenuTest.Services.Implementation;
using System.Collections;

namespace PizzaMenuTest.Models.Repositories.Implementation
{
    public class PizzaRepository(AppDbContext context) : IPizzaRepository
    {
        public ICollection<Pizza> GetAll()
        {
            return context.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            var result = context.Pizzas
                .AsNoTracking()
                .Include(p => p.Ingridients)
                .ThenInclude(i=>i.Ingridient)
                .FirstOrDefault(p => p.Id == id);
            if (result == null) { throw new NotFoundException("Cannot found Pizza with id: " + id); }
            return result;
        }

        public bool Delete(int id)
        {
            int rowAffected = context.Pizzas.Where(p=> p.Id == id).ExecuteDelete();
            return rowAffected > 0;
        }

        public Pizza Create(Pizza pizza)
        {
            pizza.Price = CalculatePrice(pizza.Ingridients);
            var result = context.Pizzas.Add(pizza).Entity;
            context.SaveChanges();
            return result;
        }

        public Pizza Update(Pizza pizza)
        {
            var toUpdate = context.Pizzas.FirstOrDefault(p => p.Id == pizza.Id);
            if (toUpdate == null) { throw new NotFoundException("No pizza with Id: " + pizza.Id); }
            context.Pizzas.Entry(toUpdate).CurrentValues.SetValues(pizza);
            //toUpdate.Price = CalculatePrice(pizza.Ingridients);
            context.SaveChanges();
            return toUpdate;

        }

        public void CalculatePrice(int pizzaId)
        {
            var pizza = context.Pizzas.Include(p=>p.Ingridients).FirstOrDefault(p => p.Id == pizzaId)!;
            pizza.Price = CalculatePrice(pizza.Ingridients);
            context.SaveChanges();
        }
        private decimal CalculatePrice(List<PizzaIngridient> pizzaIngridients)
        {
            List<Ingridient> ingridients = new List<Ingridient>();
            foreach(var pi in pizzaIngridients) 
            {
                var toAdd = context.Ingriddients.FirstOrDefault(ing=>ing.Id == pi.IngridientId);
                if (toAdd == null) { throw new NotFoundException("There no ingridient with Id: " + pi.IngridientId); }
                ingridients.Add(toAdd);
            }
            return ingridients.Sum(i=>i.Price);
        }
    }
}

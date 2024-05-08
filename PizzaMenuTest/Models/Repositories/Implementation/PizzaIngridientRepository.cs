using Microsoft.EntityFrameworkCore;
using PizzaMenuTest.Exceptions;
using PizzaMenuTest.Models.Entities;
using System.Linq;

namespace PizzaMenuTest.Models.Repositories.Implementation
{
    public class PizzaIngridientRepository(AppDbContext context) : IPizzaIngridientRepository
    {
        public IEnumerable<PizzaIngridient> GetAll()
        {
            return context.MtmPizzaIngrindient.ToList();
        }

        public IEnumerable<PizzaIngridient> GetByPizzaId(int id)
        {
            return context.MtmPizzaIngrindient.Where(pi => pi.PizzaId == id).ToList();
        }

        public IEnumerable<PizzaIngridient> GetByIngriddientId(int id)
        {
            return context.MtmPizzaIngrindient.Where(pi => pi.IngridientId == id).ToList();
        }

        public bool Delete(PizzaIngridient pizzaIngridient)
        {
            int rowAffected = context.MtmPizzaIngrindient
                .Where(pi=>pi.IngridientId == pizzaIngridient.IngridientId
                && pi.PizzaId == pizzaIngridient.PizzaId).ExecuteDelete();
            return rowAffected > 0;
        }

        public HashSet<int> DeleteByPizzaId(int id)
        {
            Pizza pizza = context.Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null) { throw new NotFoundException("Cannot foun pizza with Id: " + id); }

            List<PizzaIngridient> toDelete = context.MtmPizzaIngrindient.Where(pi => pi.PizzaId == id).ToList();
            HashSet<int> result = new HashSet<int>();
            foreach (var pi in toDelete) { result.Add(pi.IngridientId); }
            context.MtmPizzaIngrindient.Where(pi => pi.PizzaId == id).ExecuteDelete();
            return result;
        }

        public HashSet<int> DeleteByIngridientId(int id)
        {
            Ingridient ingridient = context.Ingriddients.FirstOrDefault(i => i.Id == id);
            if (ingridient == null) { throw new NotFoundException("Cannot foun Ingriient with Id: " + id); }

            List<PizzaIngridient> toDelete = context.MtmPizzaIngrindient.Where(pi => pi.IngridientId == id).ToList();
            HashSet<int> result = new HashSet<int>();
            foreach (var pi in toDelete) { result.Add(pi.PizzaId); }
            context.MtmPizzaIngrindient.Where(pi => pi.IngridientId == id).ExecuteDelete();
            return result;
        }

        public PizzaIngridient Create(PizzaIngridient pizzaIngridient)
        {
            var result = context.MtmPizzaIngrindient.Add(pizzaIngridient).Entity;
            context.SaveChanges();
            return result;
        }
        public bool CreateRange(IEnumerable<PizzaIngridient> pizzaIngridients)
        {
            context.MtmPizzaIngrindient.AddRange(pizzaIngridients);
            context.SaveChanges();
            return true;
        }

        //public bool UpdateForPizza()
    }
}

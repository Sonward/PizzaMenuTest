using Microsoft.EntityFrameworkCore;
using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories.Implementation
{
    public class IngridientRepository(AppDbContext context) : IIngridientRepository
    {
        public ICollection<Ingridient> GetAll()
        {
            return context.Ingriddients.ToList();
        }

        public Ingridient GetById(int id)
        {
            var ingridient = context.Ingriddients.FirstOrDefault(ing => ing.Id == id);
            if (ingridient == null) { throw new Exception("Cannot found ingridient with Id: " + id); }
            return ingridient;
        }
        public bool Delete(int id)
        {
            int rowAffected = context.Ingriddients.Where(ing=>ing.Id == id).ExecuteDelete();
            return rowAffected > 0;
        }

        public Ingridient Create(Ingridient ingridient)
        {
            var result = context.Ingriddients.Add(ingridient).Entity;
            context.SaveChanges();
            return result;
        }

        public Ingridient Update(Ingridient ingridient)
        {
            var toUpdate = context.Ingriddients.FirstOrDefault(ing => ing.Id == ingridient.Id);
            if (toUpdate == null)
            {
                throw new Exception("Cannot update customer with id: " + ingridient.Id);
            }
            context.Entry(toUpdate).CurrentValues.SetValues(ingridient);
            context.SaveChanges();
            return toUpdate;
        }
    }
}

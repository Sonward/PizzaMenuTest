using Microsoft.EntityFrameworkCore;
using PizzaMenuTest.Exceptions;
using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories.Implementation
{
    public class WorkerRepository(AppDbContext context) : IWorkerRepository
    {
        public ICollection<Worker> GetAll()
        {
            return context.Workers.ToList();
        }

        public Worker GetById(int id)
        {
            var result = context.Workers
                .AsNoTracking()
                .Include(w => w.Orders)
                .FirstOrDefault(w=>w.Id == id);
            if (result == null) { throw new NotFoundException("Cannot found Worker with Id: " + id); }
            return result;
        }

        public bool Delete(int id)
        {
            var rowAffected = context.Workers.Where(w=>w.Id == id).ExecuteDelete();
            return rowAffected > 0;
        }
        public Worker Create(Worker worker)
        {
            var result = context.Workers.Add(worker).Entity;
            context.SaveChanges();
            return result;
        }
        public Worker Update(Worker worker)
        {
            var toUpdate = context.Workers.FirstOrDefault(w=> w.Id == worker.Id);
            if (toUpdate != null) { throw new NotFoundException("Cannot found Worker with Id: " + worker.Id); }
            context.Workers.Entry(toUpdate).CurrentValues.SetValues(worker);
            context.SaveChanges();
            return worker;
        }
    }
}

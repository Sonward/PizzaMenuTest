using Microsoft.EntityFrameworkCore;
using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories.Implementation
{
    public class OrderPizzaRepository(AppDbContext context) : IOrderPizzaRepository
    {
        public IEnumerable<OrderPizza> GetAll()
        {
            return context.MtmOrerPizza.ToList();
        }
        public IEnumerable<OrderPizza> GetByOrerId(int id)
        {
            return context.MtmOrerPizza.Where(op=>op.OrderId == id).ToList();
        }

        public IEnumerable<OrderPizza> GetByPizzaId(int id)
        {
            return context.MtmOrerPizza.Where(op => op.PizzaId == id).ToList();
        }
        public bool Delete(OrderPizza orderPizza)
        {
            int rowAffected = context.MtmOrerPizza
                .Where(op => op.OrderId == orderPizza.OrderId
                && op.PizzaId == orderPizza.PizzaId).ExecuteDelete();
            return rowAffected > 0;
        }
        public HashSet<int> DeleteByOrderId(int id)
        {
            throw new NotImplementedException();
        }
        public HashSet<int> DeleteByPizzaId(int id)
        {
            throw new NotImplementedException();
        }
        public OrderPizza Create(OrderPizza orderPizza)
        {
            var result = context.MtmOrerPizza.Add(orderPizza).Entity;
            context.SaveChanges();
            return result;
        }
        public bool CreateRange(IEnumerable<OrderPizza> orderPizzas)
        {
            context.MtmOrerPizza.AddRange(orderPizzas);
            context.SaveChanges();
            return true;
        }
    }
}

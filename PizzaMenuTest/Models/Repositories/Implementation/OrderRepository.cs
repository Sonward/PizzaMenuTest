using Microsoft.EntityFrameworkCore;
using PizzaMenuTest.Exceptions;
using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories.Implementation
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public ICollection<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            var result = context.Orders
                .AsNoTracking()
                .Include(o => o.Pizzas)
                .ThenInclude(op => op.Pizza)
                .FirstOrDefault(o => o.Id == id);
            if (result == null) { throw new NotFoundException("Connot found Order with Id: " + id); }
            return result;
        }

        public bool Delete(int id)
        {
            var rowAffectd = context.Orders.Where(o => o.Id == id).ExecuteDelete();
            return rowAffectd > 0;
        }

        public Order Create(Order order)
        {
            order.Price = CalculatePrice(order.Pizzas);
            var result = context.Add(order).Entity;
            context.SaveChanges();
            return result;
        }

        public Order Update(Order order)
        {
            order.Price = CalculatePrice(order.Pizzas);
            var toUpdate = context.Orders.FirstOrDefault(o => o.Id == order.Id);
            if (toUpdate == null) { throw new NotFoundException("Cannot found Order with Id: " + order.Id); }
            context.Entry(toUpdate).CurrentValues.SetValues(order);
            context.SaveChanges();
            return toUpdate;
        }

        public void CalculatePrice(int orderId)
        {
            var order = context.Orders.Include(o=>o.Pizzas).FirstOrDefault(o=>o.Id == orderId);
            order.Price = CalculatePrice(order.Pizzas);
            context.SaveChanges();
        }
        private decimal CalculatePrice(List<OrderPizza> orderPizzas)
        {
            List<Pizza> pizzas = new List<Pizza>();
            foreach (var op in orderPizzas)
            {
                var toAdd = context.Pizzas.FirstOrDefault(ing => ing.Id == op.PizzaId);
                if (toAdd == null) { throw new NotFoundException("There no ingridient with Id: " + op.PizzaId); }
                pizzas.Add(toAdd);
            }
            return pizzas.Sum(i => i.Price);
        }
    }
}

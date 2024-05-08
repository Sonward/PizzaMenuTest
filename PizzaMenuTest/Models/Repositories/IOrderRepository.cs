using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories
{
    public interface IOrderRepository
    {
        public ICollection<Order> GetAll();
        public Order GetById(int id);
        public bool Delete(int id);
        public Order Create(Order order);
        public Order Update(Order order);

        public void CalculatePrice(int orderId);
    }
}

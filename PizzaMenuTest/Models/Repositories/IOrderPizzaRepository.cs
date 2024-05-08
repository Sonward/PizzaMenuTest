using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories
{
    public interface IOrderPizzaRepository
    {
        public IEnumerable<OrderPizza> GetAll();
        public IEnumerable<OrderPizza> GetByOrerId(int id);
        public IEnumerable<OrderPizza> GetByPizzaId(int id);
        public bool Delete(OrderPizza orderPizza);
        public HashSet<int> DeleteByOrderId(int id);
        public HashSet<int> DeleteByPizzaId(int id);
        public OrderPizza Create(OrderPizza orderPizza);
        public bool CreateRange(IEnumerable<OrderPizza> orderPizzas);
    }
}

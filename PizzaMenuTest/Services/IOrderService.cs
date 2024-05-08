using PizzaMenuTest.Models.Dtos;

namespace PizzaMenuTest.Services
{
    public interface IOrderService
    {
        public ICollection<OrderDto> GetAll();
        public OrderDto GetById(int id);
        public bool Delete(int id);
        public OrderDto Create(OrderCreateRequest request);
        public OrderDto Update(OrderDto request);

        public void CalculatePrice(int orderId);
        public ICollection<OrderDto> GetByCustomerId(int id);
        public ICollection<OrderDto> GetByWorkerId(int id);
    }
}

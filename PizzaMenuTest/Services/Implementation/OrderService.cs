using AutoMapper;
using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Models.Entities;
using PizzaMenuTest.Models.Repositories;
using PizzaMenuTest.Models.Repositories.Implementation;

namespace PizzaMenuTest.Services.Implementation
{
    public class OrderService(IOrderRepository orderRepository,
        IOrderPizzaRepository orderPizzaRepository,
        IMapper mapper) : IOrderService
    {
        public ICollection<OrderDto> GetAll()
        {
            return orderRepository.GetAll().Select(mapper.Map<OrderDto>).ToList();
        }

        public OrderDto GetById(int id)
        {
            return mapper.Map<OrderDto>(orderRepository.GetById(id));
        }
        public bool Delete(int id)
        {
            return orderRepository.Delete(id);
        }

        public OrderDto Create(OrderCreateRequest request)
        {
            var result = orderRepository.Create(mapper.Map<Order>(request));
            return mapper.Map<OrderDto>(result);
        }

        public OrderDto Update(OrderDto request)
        { 
            var order = mapper.Map<Order>(request);
            var result = orderRepository.Update(order);

            var currentPizzas = orderPizzaRepository.GetByOrerId(order.Id);
            var toAdd = order.Pizzas.Where(piz1 => !currentPizzas.Any(piz2 => piz2.PizzaId == piz1.PizzaId));
            var toRemove = currentPizzas.Where(piz1 => !order.Pizzas.Any(piz2 => piz2.PizzaId== piz1.PizzaId));
            orderPizzaRepository.CreateRange(toAdd);
            foreach (var piz in toRemove)
            {
                orderPizzaRepository.Delete(piz);
            }

            result.Pizzas = orderRepository.GetById(result.Id).Pizzas;
            return mapper.Map<OrderDto>(result);
        }


        public void CalculatePrice(int orderId)
        {
            orderRepository.CalculatePrice(orderId);
        }
        public ICollection<OrderDto> GetByCustomerId(int id)
        {
            return orderRepository.GetAll().Where(o=>o.CustomerId == id).Select(mapper.Map<OrderDto>).ToList();
        }
        public ICollection<OrderDto> GetByWorkerId(int id)
        {
            return orderRepository.GetAll().Where(o => o.WorkerId == id).Select(mapper.Map<OrderDto>).ToList();
        }
    }
}

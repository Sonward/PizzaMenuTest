using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Models.Entities;
using PizzaMenuTest.Services;
using PizzaMenuTest.Services.Implementation;

namespace PizzaMenuTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDto>))]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            var pizzas = orderService.GetAll();
            return Ok(pizzas);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        [ProducesResponseType(404)]
        public ActionResult<OrderDto> GetById(int id)
        {
            var pizza = orderService.GetById(id);
            return Ok(pizza);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        [ProducesResponseType(404, Type = typeof(OrderDto))]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(orderService.Delete(id));
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        public ActionResult<OrderDto> Create(OrderCreateRequest request)
        {
            var pizza = orderService.Create(request);
            return Ok(pizza);
        }

        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        [ProducesResponseType(404)]
        public ActionResult<OrderDto> Update(OrderDto request)
        {
            return Ok(orderService.Update(request));
        }
        [HttpPut("calculate price")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult CalculatePrice(int id)
        {
            orderService.CalculatePrice(id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Models.Entities;
using PizzaMenuTest.Services;

namespace PizzaMenuTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController(IPizzaService pizzaService) : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PizzaDto>))]
        public ActionResult<IEnumerable<PizzaDto>> GetAll()
        {
            var pizzas = pizzaService.GetAll();
            return Ok(pizzas);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(PizzaFullDto))]
        [ProducesResponseType(404)]
        public ActionResult<PizzaFullDto> GetById(int id) 
        {
            var pizza = pizzaService.GetById(id);
            return Ok(pizza);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200, Type = typeof(PizzaDto))]
        [ProducesResponseType(404, Type = typeof(PizzaDto))]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(pizzaService.Delete(id));
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(PizzaFullDto))]
        public ActionResult<PizzaFullDto> Create(PizzaCreateRequest request)
        {
            var pizza = pizzaService.Create(request);
            return Ok(pizza);
        }

        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(PizzaFullDto))]
        [ProducesResponseType(404)]
        public ActionResult<PizzaFullDto> Update(PizzaFullDto request)
        {
            return Ok(pizzaService.Update(request));
        }
    }
}

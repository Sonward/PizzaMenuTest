using Microsoft.AspNetCore.Mvc;
using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Services;

namespace PizzaMenuTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngridientController(IIngridientService ingridientService) : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<IngridientDto>))]
        public ActionResult<IEnumerable<IngridientDto>> GetAll()
        {
            var ingridients = ingridientService.GetAll();
            return Ok(ingridients);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(IngridientDto))]
        [ProducesResponseType(404)]
        public ActionResult<IngridientDto> GetById(int id) 
        {
            var ingridient = ingridientService.GetById(id);
            return Ok(ingridient);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200, Type = typeof(IngridientDto))]
        [ProducesResponseType(404, Type = typeof(IngridientDto))]
        public ActionResult<bool> Delete(int id) 
        {
            return Ok(ingridientService.Delete(id));
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(IngridientDto))]
        public ActionResult<IngridientDto> Create(IngridientCreateRequest request)
        {
            var ingrindient = ingridientService.Create(request);
            return Ok(ingrindient);
        }

        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(IngridientDto))]
        [ProducesResponseType(404)]
        public ActionResult<IngridientDto> Update(IngridientDto request) 
        {
            var toUpdate = ingridientService.Update(request);
            return Ok(toUpdate);
        }
    }
}

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
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CustomerDto>))]
        public ActionResult<IEnumerable<CustomerDto>> GetAll()
        {
            var customers = customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(404)]
        public ActionResult<WorkerDto> GetById(int id)
        {
            var customer = customerService.GetById(id);
            return Ok(customer);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(404, Type = typeof(CustomerDto))]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(customerService.Delete(id));
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        public ActionResult<CustomerDto> Create(CustomerCreateRequest request)
        {
            var customer = customerService.Create(request);
            return Ok(customer);
        }

        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(404)]
        public ActionResult<CustomerDto> Update(CustomerDto request)
        {
            return Ok(customerService.Update(request));
        }
    }
}

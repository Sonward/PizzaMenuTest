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
    public class WorkerController(IWorkerService workerService) : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WorkerDto>))]
        public ActionResult<IEnumerable<WorkerDto>> GetAll()
        {
            var workers = workerService.GetAll();
            return Ok(workers);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(WorkerDto))]
        [ProducesResponseType(404)]
        public ActionResult<WorkerDto> GetById(int id)
        {
            var worker = workerService.GetById(id);
            return Ok(worker);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200, Type = typeof(WorkerDto))]
        [ProducesResponseType(404, Type = typeof(WorkerDto))]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(workerService.Delete(id));
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(WorkerDto))]
        public ActionResult<WorkerDto> Create(WorkerCreateRequest request)
        {
            var worker = workerService.Create(request);
            return Ok(worker);
        }

        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(WorkerDto))]
        [ProducesResponseType(404)]
        public ActionResult<WorkerDto> Update(WorkerDto request)
        {
            return Ok(workerService.Update(request));
        }
    }
}

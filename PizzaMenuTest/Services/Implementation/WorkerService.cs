using AutoMapper;
using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Models.Entities;
using PizzaMenuTest.Models.Repositories;

namespace PizzaMenuTest.Services.Implementation
{
    public class WorkerService(IWorkerRepository workerRepository,
        IMapper mapper) : IWorkerService
    {
        public ICollection<WorkerDto> GetAll()
        {
            return  workerRepository.GetAll().Select(mapper.Map<WorkerDto>).ToList();
        }
        public WorkerDto GetById(int id)
        {
            return mapper.Map<WorkerDto>(workerRepository.GetById(id));
        }
        public bool Delete(int id)
        {
            return workerRepository.Delete(id);
        }
        public WorkerDto Create(WorkerCreateRequest request)
        {
            var result = workerRepository.Create(mapper.Map<Worker>(request));
            return mapper.Map<WorkerDto>(result);
        }
        public WorkerDto Update(WorkerDto request)
        {
            var result = workerRepository.Update(mapper.Map<Worker>(request));
            return mapper.Map<WorkerDto>(result);
        }
    }
}

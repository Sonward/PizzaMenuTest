using PizzaMenuTest.Models.Dtos;

namespace PizzaMenuTest.Services
{
    public interface IWorkerService
    {
        public ICollection<WorkerDto> GetAll();
        public WorkerDto GetById(int id);
        public bool Delete(int id);
        public WorkerDto Create(WorkerCreateRequest request);
        public WorkerDto Update(WorkerDto request);
    }
}

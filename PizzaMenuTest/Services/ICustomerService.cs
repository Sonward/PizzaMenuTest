using PizzaMenuTest.Models.Dtos;

namespace PizzaMenuTest.Services
{
    public interface ICustomerService
    {
        public ICollection<CustomerDto> GetAll();
        public CustomerDto GetById(int id);
        public bool Delete(int id);
        public CustomerDto Create(CustomerCreateRequest request);
        public CustomerDto Update(CustomerDto request);
    }
}

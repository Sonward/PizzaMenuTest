using AutoMapper;
using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Models.Entities;
using PizzaMenuTest.Models.Repositories;

namespace PizzaMenuTest.Services.Implementation
{
    public class CustomerService(ICustomerRepository customerRepository,
        IMapper mapper) : ICustomerService
    {
        public ICollection<CustomerDto> GetAll()
        {
            return customerRepository.GetAll().Select(mapper.Map<CustomerDto>).ToList();
        }
        public CustomerDto GetById(int id)
        {
            return mapper.Map<CustomerDto>(customerRepository.GetById(id));
        }
        public bool Delete(int id)
        {
            return customerRepository.Delete(id);
        }
        public CustomerDto Create(CustomerCreateRequest request)
        {
            var result = customerRepository.Create(mapper.Map<Customer>(request));
            return mapper.Map<CustomerDto>(result);
        }
        public CustomerDto Update(CustomerDto request)
        {
            var result = customerRepository.Update(mapper.Map<Customer>(request));
            return mapper.Map<CustomerDto>(result);
        }
    }
}

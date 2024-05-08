using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories
{
    public interface ICustomerRepository
    {
        public ICollection<Customer> GetAll();
        public Customer GetById(int id);
        public bool Delete(int id);
        public Customer Create(Customer customer);
        public Customer Update(Customer customer);
    }
}

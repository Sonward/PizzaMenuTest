using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PizzaMenuTest.Exceptions;
using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models.Repositories.Implementation
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {
        public ICollection<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            var result = context.Customers
                .AsNoTracking()
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.Id == id);
            if (result == null) { throw new NotFoundException("Cannot found Customer with Id: " + id); }
            return result;
        }

        public bool Delete(int id)
        {
            var customers = context.Customers.Where(c => c.Id == id);
            foreach (var customer in customers) { foreach (var order in customer.Orders) 
                {
                    if (order.Status != OrerStatus.Done 
                        || order.Status != OrerStatus.Canceled
                        || order.Status != OrerStatus.Null)
                    {
                        order.Status = OrerStatus.Canceled;
                    }
                } }
            context.SaveChanges();
            var rowsAffected = context.Customers.Where(c=>c.Id == id).ExecuteDelete();
            return rowsAffected > 0;
        }

        public Customer Create(Customer customer)
        {
            var result = context.Customers.Add(customer).Entity;
            context.SaveChanges();
            return result;
        }

        public Customer Update(Customer customer)
        {
            var toUpdate = context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (toUpdate == null) 
            {
                throw new Exception("Cannot update customer with id: " + customer.Id);
            }
            context.Customers.Entry(toUpdate).CurrentValues.SetValues(customer);
            context.SaveChanges();
            return toUpdate;
        }
    }
}

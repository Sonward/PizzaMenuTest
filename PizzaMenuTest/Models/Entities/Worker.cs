using System.ComponentModel.DataAnnotations;

namespace PizzaMenuTest.Models.Entities
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<Order> Orders { get; set; }
    }
}

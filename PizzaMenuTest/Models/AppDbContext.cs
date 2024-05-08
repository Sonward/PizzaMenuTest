using Microsoft.EntityFrameworkCore;
using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Models
{
    public class AppDbContext : DbContext
    {
        public IConfiguration _configuration { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaIngridient>().HasKey(pi => new { pi.PizzaId, pi.IngridientId });

            modelBuilder.Entity<OrderPizza>().HasKey(op => new { op.OrderId, op.PizzaId });
        }

        public DbSet<Ingridient> Ingriddients { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaIngridient> MtmPizzaIngrindient { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPizza> MtmOrerPizza { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}

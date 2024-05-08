using PizzaMenuTest.Models.Repositories;
using PizzaMenuTest.Models.Repositories.Implementation;
using PizzaMenuTest.Services;
using PizzaMenuTest.Services.Implementation;
using PizzaMenuTest.Controllers;
using PizzaMenuTest.Utilities;
using PizzaMenuTest.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddScoped<IIngridientRepository, IngridientRepository>();
        builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
        builder.Services.AddScoped<IPizzaIngridientRepository, PizzaIngridientRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderPizzaRepository, OrderPizzaRepository>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();

        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IPizzaService, PizzaService>();
        builder.Services.AddScoped<IIngridientService, IngridientService>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<IWorkerService, WorkerService>();

        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<AppDbContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
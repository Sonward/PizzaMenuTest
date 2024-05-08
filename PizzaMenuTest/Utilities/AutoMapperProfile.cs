using AutoMapper;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using PizzaMenuTest.Models.Dtos;
using PizzaMenuTest.Models.Entities;

namespace PizzaMenuTest.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Ingridient, IngridientDto>().ReverseMap();
            CreateMap<IngridientCreateRequest, Ingridient>();

            CreateMap<PizzaIngridient, PizzaIngridientDto>();

            CreateMap<Pizza, PizzaDto>().ReverseMap();
            CreateMap<PizzaCreateRequest, Pizza>()
                .ForMember(p => p.Ingridients, opt => opt.MapFrom(pcr => pcr.Ingridients
                .Select(x => new PizzaIngridient() { IngridientId = x })));
            CreateMap<Pizza, PizzaFullDto>()
                .ForMember(pfd => pfd.Ingridients, opt=>opt.MapFrom(p=>p.Ingridients
                .Select(ing=>new IngridientDto() 
                { Id = ing.IngridientId, 
                    Name = ing.Ingridient.Name,
                    Description = ing.Ingridient.Description, 
                    Price = ing.Ingridient.Price
                })));
            CreateMap<PizzaFullDto, Pizza>()
                .ForMember(p=>p.Ingridients, opt=>opt.MapFrom(pfd=>pfd.Ingridients
                .Select(ing=>new PizzaIngridient()
                {
                    IngridientId = ing.Id,
                    PizzaId = pfd.Id
                })));

            CreateMap<Order, OrderDto>()
                .ForMember(od=>od.Pizzas, opt=>opt.MapFrom(o=>o.Pizzas
                .Select(piz=> new OrderPizzaDto()
                {
                    OrerId = o.Id,
                    PizzaId = piz.PizzaId,
                    PizzaName = piz.Pizza.Name,
                    PizzaPrice = piz.Pizza.Price
                })));
            CreateMap<OrderDto, Order>()
                .ForMember(o=>o.Pizzas, opt=>opt.MapFrom(od=>od.Pizzas
                .Select(piz=>new OrderPizza()
                {
                    OrderId = piz.OrerId,
                    PizzaId = piz.PizzaId
                })));
            CreateMap<OrderCreateRequest, Order>()
                .ForMember(o => o.Pizzas, opt => opt.MapFrom(ocr => ocr.PizzasIds
                .Select(pi => new OrderPizza()
                {
                    PizzaId = pi
                })));

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerCreateRequest, Customer>();

            CreateMap<Worker, WorkerDto>().ReverseMap();
            CreateMap<WorkerCreateRequest, Worker>();
        }
    }
}

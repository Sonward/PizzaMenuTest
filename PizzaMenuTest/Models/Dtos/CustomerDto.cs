﻿using PizzaMenuTest.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace PizzaMenuTest.Models.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

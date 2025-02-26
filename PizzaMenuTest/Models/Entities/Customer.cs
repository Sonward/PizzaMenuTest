﻿using System.ComponentModel.DataAnnotations;

namespace PizzaMenuTest.Models.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Order>? Orders { get; set; }
    }
}

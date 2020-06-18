using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TableNumber { get; set; }

        [Required(ErrorMessage = "PhoneNumber Required"), MaxLength(11), MinLength(11)]
        [RegularExpression(@"^[\d]{4}[\d]{7}$", ErrorMessage = "Entered phone format is not valid 03007109721")]
        public string CustomerId { get; set; }
    }
}

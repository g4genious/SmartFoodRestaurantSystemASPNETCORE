using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TableNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public string Status { get; set; }

 
        public string CustomerId { get; set; }
    }
}

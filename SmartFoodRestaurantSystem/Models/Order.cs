using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TableNumber { get; set; }
        public DateTime? Date { get; set; }
    }
}

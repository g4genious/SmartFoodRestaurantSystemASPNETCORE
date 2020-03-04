using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class KitchenViewDB
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TableNumber { get; set; }
        public string? Quantity { get; set; }
        public string Status { get; set; }
    }
}

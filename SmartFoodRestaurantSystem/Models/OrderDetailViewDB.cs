using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class OrderDetailViewDB
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string SubTotal { get; set; } 
    }
}

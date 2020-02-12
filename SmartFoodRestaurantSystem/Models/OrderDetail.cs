using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string? Quantity { get; set; }
        public string? SubTotal { get; set; }
        public int? OrderId { get; set; }
    }
}

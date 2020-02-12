using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public DateTime? Date { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int? UnitPrice { get; set; }
        public int? ProductId { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string AddedBy { get; set; }
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}

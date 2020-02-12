using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class OrderList
    {
        [Key]
        public int Id { get; set; }
        public int? TableNumber { get; set; }
        public DateTime? Date { get; set; }
        public int? TotalAmount { get; set; }
        public string? OrderID { get; set; }
        public int? Discount { get; set; }
        public int? ServiceCharges { get; set; }
        public int? GrandTotal { get; set; }
    }
}

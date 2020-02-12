﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class OrderListViewDB
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? TotalAmount { get; set; }
        public string? OrderID { get; set; }
        public int? Discount { get; set; }
        public int? ServiceCharges { get; set; }
        public int? GrandTotal { get; set; }
        public string itemName { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string SubTotal { get; set; }


    }
}
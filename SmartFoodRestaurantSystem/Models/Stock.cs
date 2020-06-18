using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }

        public String ProductName { get; set; }
        public int In_Quantity { get; set; }
        public int Out_Quantity { get; set; }
        public int stock { get; set; }
        public virtual Product Product { get; set; }

     
    }
}
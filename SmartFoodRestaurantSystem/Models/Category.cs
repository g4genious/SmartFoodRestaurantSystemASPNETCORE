﻿using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Produce
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int? PriceHalf { get; set; }
        public int? PriceFull { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }
    }
}
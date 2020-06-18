using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Account
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}

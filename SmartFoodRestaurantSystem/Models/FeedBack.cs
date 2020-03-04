using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class FeedBack
    {
        public int? Id { get; set; }
        public string Service { get; set; }
        public string Environment { get; set; }
        public string Staff { get; set; }
        public string Food { get; set; }
    }
}

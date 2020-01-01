using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class FeedBack
    {
        public int FeedBackId { get; set; }
        public string FeedBackDescription { get; set; }
        public string FeedBackEnvironment { get; set; }
        public string FeedBackStaffBehaviour { get; set; }
        public int? CustomerId { get; set; }

        public virtual CustomerRegistration Customer { get; set; }
    }
}

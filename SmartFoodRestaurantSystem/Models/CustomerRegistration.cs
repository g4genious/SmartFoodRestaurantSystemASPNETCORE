using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class CustomerRegistration
    {
        public CustomerRegistration()
        {
            FeedBack = new HashSet<FeedBack>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int? TableId { get; set; }

        public virtual OrderTable Table { get; set; }
        public virtual ICollection<FeedBack> FeedBack { get; set; }
    }
}

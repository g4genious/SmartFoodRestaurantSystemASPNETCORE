using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class OrderTable
    {
        public OrderTable()
        {
            CustomerRegistration = new HashSet<CustomerRegistration>();
            Order = new HashSet<Order>();
            OrderMenu = new HashSet<OrderMenu>();
        }

        public int TableId { get; set; }
        public int? TableNumber { get; set; }

        public virtual ICollection<CustomerRegistration> CustomerRegistration { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<OrderMenu> OrderMenu { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class OrderMenu
    {
        public OrderMenu()
        {
            Order = new HashSet<Order>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public int? MenuPriceHalf { get; set; }
        public int? MenuPriceFull { get; set; }
        public int? MenuQuantity { get; set; }
        public int? TableId { get; set; }

        public virtual OrderTable Table { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}

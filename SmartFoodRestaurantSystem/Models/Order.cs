using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Order
    {
        public Order()
        {
            Sale = new HashSet<Sale>();
        }

        public int OrderId { get; set; }
        public int TableId { get; set; }
        public int? MenuId { get; set; }

        public virtual OrderMenu Menu { get; set; }
        public virtual OrderTable Table { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}

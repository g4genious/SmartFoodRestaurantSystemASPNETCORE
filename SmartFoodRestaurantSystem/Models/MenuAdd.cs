using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class MenuAdd
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public int? MenuPriceHalf { get; set; }
        public int? MenuPriceFull { get; set; }
        public DateTime? MenuUpdatedDate { get; set; }
        public string MenuUpdatedBy { get; set; }
        public DateTime? MenuCreatedDate { get; set; }
        public string MenuCreatedBy { get; set; }
        public string MenuStatus { get; set; }
        public int? AdminId { get; set; }

        public virtual Admin Admin { get; set; }
    }
}

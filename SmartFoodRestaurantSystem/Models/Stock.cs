using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public int? SupplierId { get; set; }
        public int? ProductId { get; set; }
        public int AdminId { get; set; }
        public string StockAddedBy { get; set; }
        public DateTime? StockAddedDate { get; set; }
        public DateTime? StockModifiedDate { get; set; }
        public string StockModifiedBy { get; set; }
        public int? UnitPrice { get; set; }
        public int? TotalAmount { get; set; }
        public string ProductType { get; set; }
        public int? CurrentStock { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Product Product { get; set; }
        public virtual SupplierRegistration Supplier { get; set; }
    }
}

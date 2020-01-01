using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? Date { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductSoldOut { get; set; }
        public int? ProductRemain { get; set; }
        public string SaleReportCreatedBy { get; set; }
        public DateTime? SaleReportCreatedDate { get; set; }
        public string SaleReportModifiedBy { get; set; }
        public DateTime? SaleReportModifiedDate { get; set; }
        public int? AdminId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

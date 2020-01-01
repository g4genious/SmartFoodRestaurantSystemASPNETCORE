using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? SupplierId { get; set; }
        public DateTime? Date { get; set; }
        public int? Credit { get; set; }
        public int? Cash { get; set; }

        public virtual SupplierRegistration Supplier { get; set; }
    }
}

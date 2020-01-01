using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class SupplierRegistration
    {
        public SupplierRegistration()
        {
            Payment = new HashSet<Payment>();
            Product = new HashSet<Product>();
            Stock = new HashSet<Stock>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhoneNumber { get; set; }
        public string SupplierCompany { get; set; }
        public int? AdminId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}

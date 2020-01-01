using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Product
    {
        public Product()
        {
            Sale = new HashSet<Sale>();
            Stock = new HashSet<Stock>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductQuantity { get; set; }
        public int? ProductPrice { get; set; }
        public DateTime? ProductReceivedDate { get; set; }
        public string ProductReceivedBy { get; set; }
        public DateTime? ProductReturnDate { get; set; }
        public string ProductReturnBy { get; set; }
        public DateTime? ProductUpdatedDate { get; set; }
        public string ProductUpdatedBy { get; set; }
        public int? SupplierId { get; set; }

        public virtual SupplierRegistration Supplier { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Product
    {
        public Product()
        {
            Stock = new HashSet<Stock>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string Details { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }

        public int SubTotal { get; set; }
        public int Stock_Quantity { get; set; }
        public int Total { get; set; }
        //public int Grand_Total { get; set; }
        public int Paid_Amount { get; set; }
        public string Payment_Type { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Stock> Stock { get; set; }
    }
}
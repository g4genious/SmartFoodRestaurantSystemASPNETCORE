using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class SupplierAccount
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
        public int Balance { get; set; }
        public int GrandTotal { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
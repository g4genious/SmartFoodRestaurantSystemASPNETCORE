using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{

    public partial class Supplier
    {
        public Supplier()
        {
            Product = new HashSet<Product>();
            SupplierAccount = new HashSet<SupplierAccount>();
            //Stock = new HashSet<Stock>();
        }


        public int Id { get; set; }


        public string Name { get; set; }
        [Required(ErrorMessage ="PhoneNumber Required"), MaxLength(11), MinLength(11) ]
        [RegularExpression(@"^[\d]{4}[\d]{7}$", ErrorMessage = "Entered phone format is not valid 03007109721")]


        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<SupplierAccount> SupplierAccount { get; set; }

        //public virtual ICollection<Stock> Stock { get; set; }
    }
}

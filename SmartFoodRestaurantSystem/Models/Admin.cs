using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Admin
    {
        public Admin()
        {
            MenuAdd = new HashSet<MenuAdd>();
            Sale = new HashSet<Sale>();
            StaffRegistration = new HashSet<StaffRegistration>();
            Stock = new HashSet<Stock>();
            SupplierRegistration = new HashSet<SupplierRegistration>();
        }

        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<MenuAdd> MenuAdd { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
        public virtual ICollection<StaffRegistration> StaffRegistration { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
        public virtual ICollection<SupplierRegistration> SupplierRegistration { get; set; }
    }
}

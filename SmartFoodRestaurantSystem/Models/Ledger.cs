using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class Ledger
    {
        public int Id { get; set; }
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
        public string PaymentType { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}

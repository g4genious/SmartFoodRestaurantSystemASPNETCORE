
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class ProduceViewClass
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ItemName Can Not Greater Be Then 15 Characters"), MaxLength(15)]
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Description Can Not Greater Be Less Then 20 And Greater Then 30 Characters "), MaxLength(30), MinLength(20)]
        public string Description { get; set; }
        public int? PriceHalf { get; set; }
        public int? PriceFull { get; set; }
        public int? PriceMedium { get; set; }
        public string TopCategory { get; set; }
        public string Category { get; set; }
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }
    }
}
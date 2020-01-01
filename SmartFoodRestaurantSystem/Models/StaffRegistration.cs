using System;
using System.Collections.Generic;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class StaffRegistration
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffAddress { get; set; }
        public string StaffCnic { get; set; }
        public string StaffPhoneNumber { get; set; }
        public DateTime? StaffJobStartDate { get; set; }
        public DateTime? StaffJobEndDate { get; set; }
        public string StaffRole { get; set; }
        public TimeSpan? StaffShiftTime { get; set; }
        public int? AdminId { get; set; }

        public virtual Admin Admin { get; set; }
    }
}

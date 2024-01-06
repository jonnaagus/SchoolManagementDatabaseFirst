using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Staff
    {
        public int StaffID { get; set; }
        public string FirstName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
    }
}

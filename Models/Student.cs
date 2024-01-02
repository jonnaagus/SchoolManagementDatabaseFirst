using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; } = null!;
        public string PersonalIdnr { get; set; } = null!;
        public string Class { get; set; } = null!;
        public string LastName { get; set; } = null!;

        // Navigationsegenskap för betyg
        public virtual ICollection<Grade>? Grades { get; set; }
    }
}


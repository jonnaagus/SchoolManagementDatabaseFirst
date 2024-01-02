using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; } = null!;

        // Navigationsegenskap för betyg
        public virtual ICollection<Grade>? Grades { get; set; }
    }
}

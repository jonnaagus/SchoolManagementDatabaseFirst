using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Course
    {
        public Course()
        {
            Grades = new HashSet<Grade>();
        }

        public int CourseID { get; set; }
        public string CourseName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}

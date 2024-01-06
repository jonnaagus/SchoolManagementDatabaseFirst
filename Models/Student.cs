using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int StudentID { get; set; }
        public string FirstName { get; set; } = null!;
        public string PersonalIDNr { get; set; } = null!;
        public string ClassName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}

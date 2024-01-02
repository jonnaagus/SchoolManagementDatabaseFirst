using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public DateTime GradeDate { get; set; }
        public string Value { get; set; } = null!;

        // FK till Student-tabellen
        public int _FKStudentId { get; set; }
        public virtual Student? Student { get; set; }

        // FK till Courses-tabellen
        public int _FKCourseId { get; set; }
        public virtual Course? Course { get; set; }

    }
}


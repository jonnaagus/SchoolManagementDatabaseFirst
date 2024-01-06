using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class GivesGrade
    {
        public int FKTeacherID { get; set; }
        public int FKCourseID { get; set; }
        public int FKGradeID { get; set; }
        public int FKStudentID { get; set; }
        public DateTime? GradeDate { get; set; }

        public Teacher? Teacher { get; set; }
    }
}

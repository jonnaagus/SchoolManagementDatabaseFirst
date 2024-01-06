using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Enroll
    {
        public int FKStudentID { get; set; }
        public int FKCourseID { get; set; }
    }
}

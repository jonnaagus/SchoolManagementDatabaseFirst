using System;


namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public DateTime GradeDate { get; set; }
        public string GradeValue { get; set; } = null!;
        public int FKStudentID { get; set; }
        public int FKCourseID { get; set; }
        public int FKTeacherID { get; set; }    

        // Uppdaterade navigationsegenskaper
        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class GivesGrade
    {
        public int FkteacherId { get; set; }
        public int FkcourseId { get; set; }
        public int FkgradeId { get; set; }
    }
}

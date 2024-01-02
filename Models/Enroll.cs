using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Enroll
    {
        public int FkstudentId { get; set; }
        public int FkcourseId { get; set; }
    }
}

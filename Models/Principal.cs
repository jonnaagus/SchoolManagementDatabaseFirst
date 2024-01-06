using System;
using System.Collections.Generic;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class Principal
    {
        public int PrincipalID { get; set; } 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public string Position { get; set; } = null!;
    }
}

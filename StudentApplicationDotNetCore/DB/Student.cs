using System;
using System.Collections.Generic;

#nullable disable

namespace StudentApplicationDotNetCore.DB
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RollNo { get; set; }
        public decimal Marks { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }
    }
}

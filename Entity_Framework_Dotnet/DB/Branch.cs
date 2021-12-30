using System;
using System.Collections.Generic;

#nullable disable

namespace Entity_Framework_Dotnet.DB
{
    public partial class Branch
    {
        public Branch()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}

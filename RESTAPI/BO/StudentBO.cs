using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.BO
{
    public class StudentBO
    {
       
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int? RollNo { get; set; }
            public decimal? Marks { get; set; }
            public string Branch { get; set; }
            public int? BranchId { get; set; }
            public string BranchName { get; set; }
        
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentApplication.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TrainingModel : DbContext
    {
        public TrainingModel()
            : base("name=TrainingModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Student> Student { get; set; }
    
        public virtual ObjectResult<Nullable<decimal>> CreateStudent(string firstname, string lastname, Nullable<int> rollno, Nullable<decimal> marks)
        {
            var firstnameParameter = firstname != null ?
                new ObjectParameter("firstname", firstname) :
                new ObjectParameter("firstname", typeof(string));
    
            var lastnameParameter = lastname != null ?
                new ObjectParameter("lastname", lastname) :
                new ObjectParameter("lastname", typeof(string));
    
            var rollnoParameter = rollno.HasValue ?
                new ObjectParameter("rollno", rollno) :
                new ObjectParameter("rollno", typeof(int));
    
            var marksParameter = marks.HasValue ?
                new ObjectParameter("marks", marks) :
                new ObjectParameter("marks", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("CreateStudent", firstnameParameter, lastnameParameter, rollnoParameter, marksParameter);
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Operations.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmployeeEntities : DbContext
    {
        public EmployeeEntities()
            : base("name=EmployeeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_City> TBL_City { get; set; }
        public virtual DbSet<TBL_Country> TBL_Country { get; set; }
        public virtual DbSet<TBL_Employee> TBL_Employee { get; set; }
        public virtual DbSet<TBL_State> TBL_State { get; set; }
    }
}

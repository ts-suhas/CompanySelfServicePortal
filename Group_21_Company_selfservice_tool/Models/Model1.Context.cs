﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group_21_Company_selfservice_tool.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FDBProjectEntities3 : DbContext
    {
        public FDBProjectEntities3()
            : base("name=FDBProjectEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Awards> Awards { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<KT_Documents> KT_Documents { get; set; }
        public virtual DbSet<Leaves> Leaves { get; set; }
        public virtual DbSet<Meal_Plan> Meal_Plan { get; set; }
        public virtual DbSet<Medical_Insurance> Medical_Insurance { get; set; }
        public virtual DbSet<Parking> Parking { get; set; }
        public virtual DbSet<Payroll> Payroll { get; set; }
        public virtual DbSet<Pension_Account> Pension_Account { get; set; }
        public virtual DbSet<Personal_Profile> Personal_Profile { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Repository> Repository { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Skillset> Skillset { get; set; }
        public virtual DbSet<Timesheet> Timesheet { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Work_Mode> Work_Mode { get; set; }
    }
}
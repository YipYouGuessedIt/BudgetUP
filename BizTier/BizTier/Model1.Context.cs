﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BizTier
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dboEntities : DbContext
    {
        public dboEntities()
            : base("name=dboEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Admin_SysSettings> Admin_SysSettings { get; set; }
        public DbSet<AirlineExpens> AirlineExpenses { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Bursary> Bursaries { get; set; }
        public DbSet<BursaryType> BursaryTypes { get; set; }
        public DbSet<CarExpens> CarExpenses { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<DurationType> DurationTypes { get; set; }
        public DbSet<EmailDomain> EmailDomains { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Expens> Expenses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Gautrain> Gautrains { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Operation_Type> Operation_Type { get; set; }
        public DbSet<Operational> Operationals { get; set; }
        public DbSet<PostLevel> PostLevels { get; set; }
        public DbSet<Project_Settings> Project_Settings { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<UPStaffMember> UPStaffMembers { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visa> Visas { get; set; }
    }
}

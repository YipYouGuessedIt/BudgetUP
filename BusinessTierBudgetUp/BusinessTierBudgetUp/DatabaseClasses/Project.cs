//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessTierBudgetUp.DatabaseClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.Objectives = new HashSet<Objective>();
            this.Incomes = new HashSet<Income>();
            this.Bursaries = new HashSet<Bursary>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Goal { get; set; }
        public int Length { get; set; }
        public int DurationTypeId { get; set; }
    
        public virtual ICollection<Objective> Objectives { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Bursary> Bursaries { get; set; }
        public virtual User User { get; set; }
        public virtual Project_Settings Project_Settings { get; set; }
        public virtual DurationType DurationType { get; set; }
    }
}

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
    
    public partial class Activity
    {
        public Activity()
        {
            this.Expenses = new HashSet<Expense>();
        }
    
        public int Id { get; set; }
        public int ObjectiveId { get; set; }
        public string ActivityName { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
    
        public virtual Objective Objective { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
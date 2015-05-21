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
    
    public partial class Expense
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public double Amount { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual UPStaffMember UPStaffMember { get; set; }
        public virtual Contractor Contractor { get; set; }
        public virtual Travel Travel { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Operational Operational { get; set; }
        public virtual Note Note { get; set; }
    }
}

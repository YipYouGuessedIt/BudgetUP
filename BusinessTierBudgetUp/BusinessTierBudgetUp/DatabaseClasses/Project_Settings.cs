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
    
    public partial class Project_Settings
    {
        public int Id { get; set; }
        public double EscalationRate { get; set; }
        public double SubventionRate { get; set; }
        public double InstitutionalCost { get; set; }
    
        public virtual Project Project { get; set; }
    }
}

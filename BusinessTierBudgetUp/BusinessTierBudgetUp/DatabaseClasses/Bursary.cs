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
    
    public partial class Bursary
    {
        public int Id { get; set; }
        public int BursaryTypeId { get; set; }
        public int ProjectId { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual BursaryType BursaryType { get; set; }
        public virtual Note Note { get; set; }
    }
}

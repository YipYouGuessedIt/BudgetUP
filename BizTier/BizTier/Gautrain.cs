//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Gautrain
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int Travel_Id { get; set; }
    
        public virtual Travel Travel { get; set; }
    }
}


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
    
public partial class Car
{

    public int Id { get; set; }

    public bool UPFleet { get; set; }

    public int ExpensId { get; set; }



    public virtual Expens Expen { get; set; }

}

}

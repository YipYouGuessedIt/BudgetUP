
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
    
public partial class User
{

    public User()
    {

        this.Projects = new HashSet<Project>();

        this.UserCredentials = new HashSet<UserCredential>();

    }


    public int Id { get; set; }

    public int TitleId { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public int RoleId { get; set; }

    public int FacultyId { get; set; }

    public Nullable<bool> Admin { get; set; }



    public virtual Faculty Faculty { get; set; }

    public virtual ICollection<Project> Projects { get; set; }

    public virtual Role Role { get; set; }

    public virtual Title Title { get; set; }

    public virtual ICollection<UserCredential> UserCredentials { get; set; }

}

}

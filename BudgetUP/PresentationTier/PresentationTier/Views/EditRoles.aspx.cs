using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (this.Session["Admin"].ToString() == "True".ToString())
            {
                adminnav.Visible = true;
                normalnav.Visible = false;
            }
            else
            {
                adminnav.Visible = false;
                normalnav.Visible = true;
            }
            if (this.Session["RoleTypeID"] == null)
            {
                Response.Redirect("Settings.aspx");
            }
            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from Roles
                                in dbContext.Roles
                                select Roles;


                    foreach (Role p in query)
                    {
                        if (p.Id.ToString() == Session["RoleTypeID"].ToString())
                        {
                            RoleDescription.Text = p.Description.ToString();
                        }
                        
                    }

                }
            }
        }

        protected void addBursary(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();

            Role bt = new Role();

            bt.Id = Convert.ToInt32(this.Session["RoleTypeID"].ToString());
            bt.Description = RoleDescription.Text;
            sc.UpdateRole(bt);

            Response.Redirect("Settings.aspx");
        }

        protected void DeleteRoles(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteRole(Convert.ToInt32(this.Session["RoleTypeID"].ToString()));
            Response.Redirect("Settings.aspx");
        }
    }
}
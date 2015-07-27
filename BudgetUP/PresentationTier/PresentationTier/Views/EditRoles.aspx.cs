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
            try
            {
                errormsg.Visible = false;
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (Session["RoleTypeID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
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
                            if(!IsPostBack)
                            RoleDescription.Text = p.Description.ToString();
                        }
                        
                    }

                }
            }
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void addBursary(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();

            Role bt = new Role();

            bt.Id = Convert.ToInt32(this.Session["RoleTypeID"].ToString());
            bt.Description = RoleDescription.Text;
            sc.UpdateRole(bt);

            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void DeleteRoles(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteRole(Convert.ToInt32(this.Session["RoleTypeID"].ToString()));
            this.Session["RoleTypeID"] = null;
            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                errormsg.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }
    }
}
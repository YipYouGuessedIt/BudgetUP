using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class AddFaculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // errormsg.Visible.Visible = false;
            if (Session.Count == 0)
            {

                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (this.Session["Admin"].ToString() == "False".ToString())
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
            tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a>  &gt <a href='Settings.aspx'>Settings</a>  &gt Add Faculty Type";

            }
            catch (Exception err)
            {

                // errormsg.Visible.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void addRole(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();
            sc.AddFaculty(FacultyName.Text);
            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

                // errormsg.Visible.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                // errormsg.Visible.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                // errormsg.Visible.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }
    }
}
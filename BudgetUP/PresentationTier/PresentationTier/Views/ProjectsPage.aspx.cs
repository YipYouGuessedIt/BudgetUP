using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class ProjectsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session.Count == 0)
            {
                Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
             String cont = "Welcome " + this.Session["userTitle"] + " " + this.Session["userSname"];
             wecomemsg.InnerHtml = "<h1>" + cont + "</h1>";
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
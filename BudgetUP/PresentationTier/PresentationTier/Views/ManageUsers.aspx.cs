using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if(this.Session["Admin"].ToString() != "true".ToString())
            {
                Response.Redirect("ProjectsPage.aspx");
            }
            using (var dbContext = new dboEntities())
            {
                var query = from users
                            in dbContext.Users
                            select users;


                //px = query2;
                foreach (User v in query)
                {
                    LinkButton add = new LinkButton();
                    add.Text = v.Name + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                    add.ID = v.Id.ToString() + "Income";
                    add.CssClass = "list-group-item";
                    add.Click += new EventHandler(Eclicker);
                    BursaryList.Controls.Add(add);
                }
            }
        }

        protected void Eclicker(object sender, EventArgs e)
        {
            LinkButton m = (LinkButton)sender;
            char[] ma = "Income".ToCharArray();
            Session["UserID"] = m.ID.Split(ma)[0];
            Response.Redirect("ProfilePage.aspx");
        }
    }
}
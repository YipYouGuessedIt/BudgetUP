using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class Post : System.Web.UI.Page
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
            if (this.Session["PostID"] == null)
            {
                Response.Redirect("Settings.aspx");
            }

            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from BursaryTypes
                                in dbContext.PostLevels
                                select BursaryTypes;


                    foreach (PostLevel p in query)
                    {
                        if (p.Id.ToString() == Session["PostID"].ToString())
                        {
                            if (!IsPostBack)
                            {
                                FacultyName.Text = p.Description.ToString();
                                FacultyName0.Text = p.AnnualSalary.ToString();
                            }
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

        protected void addRole(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();

            PostLevel bt = new PostLevel();

            bt.Id = Convert.ToInt32(this.Session["PostID"].ToString());
            bt.Description = FacultyName.Text;
            bt.AnnualSalary = FacultyName0.Text;

            sc.UpdatePostLevel(bt);

            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();
            sc.DeletePostLevel(Convert.ToInt32(this.Session["PostID"].ToString()));
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
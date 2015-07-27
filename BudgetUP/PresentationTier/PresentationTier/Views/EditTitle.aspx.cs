using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditTitle : System.Web.UI.Page
    {
        protected void addBursaryType(object sender, EventArgs e)
        {
            try
            {

            ServiceContracts sc = new ServiceContracts();

            Title bt = new Title();

            bt.Id = Convert.ToInt32(this.Session["TitlesID"].ToString());
            bt.Description = FacultyDescription.Text;

            sc.UpdateTitle(bt);

            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

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
            if (this.Session["TitlesID"] == null)
            {
                Response.Redirect("Settings.aspx");
            }
            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from BursaryTypes
                                in dbContext.Titles
                                select BursaryTypes;


                    foreach (Title p in query)
                    {
                        if (p.Id.ToString() == Session["TitlesID"].ToString())
                        {
                            if (!IsPostBack)
                            {
                                FacultyDescription.Text = p.Description.ToString();
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

        protected void DeleteFaculty(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteTitle(Convert.ToInt32(this.Session["TitlesID"].ToString()));
            this.Session["TitlesID"] = null;
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
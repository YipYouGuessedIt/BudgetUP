using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditFaculty : System.Web.UI.Page
    {
        protected void addBursaryType(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();

            Faculty bt = new Faculty();

            bt.Id = Convert.ToInt32(this.Session["FacultyID"].ToString());
            bt.FacultyName = FacultyDescription.Text;

            sc.UpdateFaculty(bt);

            Response.Redirect("Settings.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (this.Session["FacultyID"] == null)
            {
                Response.Redirect("Settings.aspx");
            }
            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from BursaryTypes
                                in dbContext.Faculties
                                select BursaryTypes;


                    foreach (Faculty p in query)
                    {
                        if (p.Id.ToString() == Session["FacultyID"].ToString())
                        {
                            if (!IsPostBack)
                            {
                                FacultyDescription.Text = p.FacultyName.ToString();
                            }
                        }
                    }
                }
            }
        }

        protected void DeleteFaculty(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteFaculty(Convert.ToInt32(this.Session["FacultyID"].ToString()));
            Response.Redirect("Settings.aspx");
        }
    }
}
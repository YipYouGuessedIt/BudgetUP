using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ActID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }
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

            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Activities
                            select Projects;


                foreach (Activity p in query)
                {
                    if (p.Id.ToString() == Session["ActID"].ToString())
                    {
                        if (!IsPostBack)
                        {
                            ActName.Text = p.ActivityName;
                            edate.Text = p.EndDate.ToString("yyyy-MM-dd");
                            sdate.Text = p.StartDate.ToString("yyyy-MM-dd");

                        }
                    }
                }
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            using (var dbContext = new dboEntities())
            {
                var query2 = from Project
                             in dbContext.Projects
                             select Project;

                foreach (Project m in query2)
                {
                    if (m.Id.ToString() == Session["projectID"].ToString())
                    {
                        DateTime start = Convert.ToDateTime(sdate.Text);
                        DateTime end = Convert.ToDateTime(edate.Text);
                        if (m.StartDate > start || m.EndDate > end)
                        {
                            ServiceContracts mb = new ServiceContracts();
                            Activity p = new Activity();
                            p.Id = Convert.ToInt32(Session["ActID"].ToString());
                            p.ActivityName = ActName.Text;
                            p.StartDate = Convert.ToDateTime(sdate.Text);
                            p.EndDate = Convert.ToDateTime(edate.Text);
                            mb.UpdateActivity(p);
                        }
                        else
                        {

                        }
                        Response.Redirect("IncomeandExpensesPage.aspx");
                    }
                }

            }

        }
        protected void Unnamed4_Click2(object sender, EventArgs e)
        {
            ServiceContracts m = new ServiceContracts();

            m.DeleteUserProject(Convert.ToInt32(Session["ActID"].ToString()));
            Response.Redirect("IncomeandExpensesPage.aspx");
        }
    }
}
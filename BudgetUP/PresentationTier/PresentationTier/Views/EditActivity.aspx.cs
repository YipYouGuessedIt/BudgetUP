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
                            edate.Text = p.EndDate.ToString();
                            sdate.Text = p.StartDate.ToString();

                        }
                    }
                }
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            ServiceContracts m = new ServiceContracts();
            Activity p = new Activity();
            p.Id = Convert.ToInt32(Session["ActID"].ToString());
            p.ActivityName = ActName.Text;
            p.StartDate = Convert.ToDateTime(sdate.Text);
            p.EndDate = Convert.ToDateTime(edate.Text);
            m.UpdateActivity(p);
        }
        protected void Unnamed4_Click2(object sender, EventArgs e)
        {
            ServiceContracts m = new ServiceContracts();

            m.DeleteUserProject(Convert.ToInt32(Session["ActID"].ToString()));
        }
    }
}
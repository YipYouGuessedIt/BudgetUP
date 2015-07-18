using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class editSettings : System.Web.UI.Page
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
            if (this.Session["projectID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }
            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from BursaryTypes
                                in dbContext.Projects
                                select BursaryTypes;


                    foreach (Project p in query)
                    {
                        if (p.Id.ToString() == this.Session["projectID"].ToString())
                        {
                            if (!IsPostBack)
                            {
                                EscalationRate.Text = p.Project_Settings.EscalationRate.ToString();
                                InstutionalCost.Text = p.Project_Settings.InstitutionalCost.ToString();
                               // MaximumSpan.Text = p.MaximumProjectSpan.ToString();
                                Subvention.Text = p.Project_Settings.SubventionRate.ToString();
                            }
                        }
                    }
                }
            }
        }

        protected void addBursaryType(object sender, EventArgs e)
        {
            using (var dbContext = new dboEntities())
            {
                var query = from BursaryTypes
                            in dbContext.Projects
                            select BursaryTypes;


                foreach (Project p in query)
                {
                    if (p.Id.ToString() == this.Session["projectID"].ToString())
                    {
                        Project_Settings m = new Project_Settings();
                        m.Id = p.Project_Settings_Id;
                        m.EscalationRate = Convert.ToDouble(EscalationRate.Text);
                        m.InstitutionalCost = Convert.ToDouble(InstutionalCost.Text);
                        m.SubventionRate = Convert.ToDouble(Subvention.Text);
                        ServiceContracts n = new ServiceContracts();
                        n.UpdateProjectSettings(m);
                        Response.Redirect("ObjectivesPage.aspx");
                            //EscalationRate.Text = p.Project_Settings.EscalationRate.ToString();
                            //InstutionalCost.Text = p.Project_Settings.InstitutionalCost.ToString();
                            //// MaximumSpan.Text = p.MaximumProjectSpan.ToString();
                            //Subvention.Text = p.Project_Settings.SubventionRate.ToString();
                    }
                }
            }
        }
    }
}
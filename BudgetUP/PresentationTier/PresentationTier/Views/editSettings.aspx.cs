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
            try
            { 
            //errormsg.Visible = true;
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
                    treeviewer.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt <a href='ObjectivesPage.aspx'>Project Details and Objective List</a> &gt  <a href='EditProject.aspx'>Edit Project </a> %gt Edit Settings";
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
                                uprate.Text = p.Project_Settings.UPFleetDailyRate.ToString();
                                fc.Text = p.Project_Settings.FCkmRate.ToString();
                                TextBox1.Text = p.Project_Settings.UPFleetKmRate.ToString();

                            }
                        }
                    }
                }
            }
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
        }

        protected void addBursaryType(object sender, EventArgs e)
        {
            try
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
                        m.UPFleetDailyRate = Convert.ToDouble(uprate.Text);
                        m.FCkmRate = Convert.ToDouble(fc.Text);
                        m.UPFleetKmRate = Convert.ToDouble(TextBox1.Text);
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
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
        }
    }
}
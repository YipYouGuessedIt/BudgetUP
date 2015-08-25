using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class AddActivities1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            // errormsg.Visible = false;
            if (Session.Count == 0)
            {
                
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (Session["ObjectiveID"] == null)
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
            if (!IsPostBack)
            {
                sdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                edate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            treeviewer.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt <a href='ActivitiesPage.aspx'>Project Details and Objective List</a> &gt <a href='ObjectivesPage.aspx'>Objective Details and Activity List</a> &gt Add Activities";

            }
            catch (Exception err)
            {

                // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            try
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
                              if (start >= DateTime.Today)
            {
            if (end >= start)
            {
                        if (m.StartDate > start || m.EndDate > end)
                        {
                            ServiceContracts sc = new ServiceContracts();
                            sc.AddActivity(Convert.ToInt32(Session["ObjectiveID"].ToString()), ActName.Text, Convert.ToDateTime(sdate.Text), Convert.ToDateTime(edate.Text));
                            Response.Redirect("ActivitiesPage.aspx");
                        }
                        else
                        {
                            // errormsg.Visible = true;
                            messageforerror.InnerHtml = "Dates dont fall in projects bounds";
                            ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

                        }
            }
            else
            {
                //errormsg.Visible = true;
                messageforerror.InnerHtml = "End date is befor start date";
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
            }
                              else
                              {
                                  //errormsg.Visible = true;
                                  messageforerror.InnerHtml = "Start date is befor todays date";
                                  ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
                              }
                        
                    }
                }

            }
            }
            catch (Exception err)
            {

                // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                // errormsg.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }
    }
}
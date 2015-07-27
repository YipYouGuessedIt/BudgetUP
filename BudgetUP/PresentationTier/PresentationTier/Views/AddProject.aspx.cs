using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class AddProject : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                sdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                edate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void AddProject_Click(object sender, EventArgs e)
        {
            try { 
            using (var dbContext = new dboEntities())
            {
            ServiceContracts project = new ServiceContracts();
            int userID = Convert.ToInt32(this.Session["userID"]);
            DateTime start = Convert.ToDateTime(sdate.Text);
            DateTime end = Convert.ToDateTime(edate.Text);
            if (start >= DateTime.Today)
            {
            if (end >= start)
            {
                int length;
                if(end.Day < start.Day)
                {
                    length = (end.Year - start.Year) * 12 + end.Month - start.Month - 1;
                }
                else
                {
                    length = (end.Year - start.Year) * 12 + end.Month - start.Month;
                    if(length == 0)
                    {
                        length = 1;
                    }
                }

                 var query = from adminSyssettings
                 in dbContext.Admin_SysSettings
                 select adminSyssettings;

                 int value2 = query.Count<Admin_SysSettings>();
                 int num = 1;

                  foreach (Admin_SysSettings mi in query)
                  {
                  if(num == value2)
                  {
                        ServiceContracts mn = new ServiceContracts();
                        mn.AddProjectSettings(mi.EscalationRate, mi.SubventionRate, mi.InstitutionalCost);
                        var query2 = from Project_Settings
                        in dbContext.Project_Settings
                        select Project_Settings;

                        int value = query2.Count<Project_Settings>();
                        int counter = 1;
                        foreach (Project_Settings m in query2)
                        {
                            if (counter == value)
                            {
                                this.Session["projectID"] = project.AddUserProject(userID, title.Text, goal.Text, length, m.Id , start, end);
                            }
                            counter++;
                        }
                  }
                    num++;
                                
                  }
                       
            }  
            else
            {
                errormsg.Visible = true;
                messageforerror.Text = "End date is befor start date";
            }
                }  
            else
            {
                errormsg.Visible = true;
                messageforerror.Text = "Start date is befor todays date";
            }

 
                
            }
            Response.Redirect("ObjectivesPage.aspx");
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
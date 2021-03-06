﻿using System;
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
            //errormsg.Visible = false;
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

            treeviewer.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt Add Project";

            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
        }

        protected void AddProject_Click(object sender, EventArgs e)
        {
            try { 
            using (var dbContext = new dboEntities())
            {
                bool msd = false;
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
                      if (length < (mi.MaximumProjectSpan *12))
                      {
                          ServiceContracts mn = new ServiceContracts();
                          mn.AddProjectSettings(mi.EscalationRate, mi.SubventionRate, mi.InstitutionalCost, mi.UPFleetDailyRate, mi.FCkmRate, mi.UPFleetKmRate);
                          var query2 = from Project_Settings
                          in dbContext.Project_Settings
                                       select Project_Settings;
                          msd = true;
                          int value = query2.Count<Project_Settings>();
                          int counter = 1;
                          foreach (Project_Settings m in query2)
                          {
                              if (counter == value)
                              {
                                  this.Session["projectID"] = project.AddUserProject(userID, title.Text, goal.Text, length, m.Id, start, end);
                              }
                              counter++;
                          }
                      }
                      
                  }
                    num++;
                                
                  }
                if(msd)
                {
                  Response.Redirect("ObjectivesPage.aspx");
                }
                else
                      {
                          messageforerror.InnerHtml = "Project exceeds the maximum project span";
                          ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
           
                      }
            }  
            else
            {
                //errormsg.Visible = true;
                messageforerror.InnerHtml = "End date is before start date";
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
                }  
            else
            {
                //errormsg.Visible = true;
                messageforerror.InnerHtml = "Start date is before todays date";
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
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
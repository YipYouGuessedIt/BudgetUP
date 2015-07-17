﻿using System;
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
                            ServiceContracts sc = new ServiceContracts();
                            sc.AddActivity(Convert.ToInt32(Session["ObjectiveID"].ToString()), ActName.Text, Convert.ToDateTime(sdate.Text), Convert.ToDateTime(edate.Text));
                        }
                        else
                        {

                        }
                        Response.Redirect("ActivitiesPage.aspx");
                    }
                }

            }
        }
    }
}
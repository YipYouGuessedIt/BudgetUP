﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditObjectives : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                errormsg.Visible = false;
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

            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Objectives
                            select Projects;


                foreach (Objective p in query)
                {
                    if (p.Id.ToString() == Session["ObjectiveID"].ToString())
                    {
                        if (!IsPostBack)
                        {
                            ObjName.Text = p.ObjectiveName;

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

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts m = new ServiceContracts();
            Objective n = new Objective();
            n.Id = Convert.ToInt32(Session["ObjectiveID"].ToString());
            n.ObjectiveName = ObjName.Text;
            Response.Redirect("ActivitiesPage.aspx");
                        }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
            
        }
        protected void Unnamed3_Click2(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts m = new ServiceContracts();
            m.DeleteObjectives(Convert.ToInt32(Session["ObjectiveID"].ToString()));
            Response.Redirect("ActivitiesPage.aspx");
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
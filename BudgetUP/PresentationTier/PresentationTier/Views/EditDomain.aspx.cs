﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditDomain : System.Web.UI.Page
    {
        

        protected void addBursaryType(object sender, EventArgs e)
        {
            try{
            ServiceContracts sc = new ServiceContracts();

            EmailDomain bt = new EmailDomain();

            bt.Id = Convert.ToInt32(this.Session["DomainID"].ToString());
            bt.Domain = FacultyDescription.Text;

            sc.UpdateEmailDomain(bt);

            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

               // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a>  &gt <a href='Settings.aspx'>Settings</a>  &gt Edit Domain Type";

               // errormsg.Visible = false;
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (Session["DomainID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
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
            if (this.Session["DomainID"] == null)
            {
                Response.Redirect("Settings.aspx");
            }
            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from BursaryTypes
                                in dbContext.EmailDomains
                                select BursaryTypes;


                    foreach (EmailDomain p in query)
                    {
                        if (p.Id.ToString() == Session["DomainID"].ToString())
                        {
                            if (!IsPostBack)
                            {
                                FacultyDescription.Text = p.Domain.ToString();
                            }
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

        protected void DeleteFaculty(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteEmailDomain(Convert.ToInt32(this.Session["DomainID"].ToString()));
            this.Session["DomainID"] = null;
            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

               // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void FacultyDescription_TextChanged(object sender, EventArgs e)
        {

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
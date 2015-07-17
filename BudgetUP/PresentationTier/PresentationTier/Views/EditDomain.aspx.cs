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
            ServiceContracts sc = new ServiceContracts();

            EmailDomain bt = new EmailDomain();

            bt.Id = Convert.ToInt32(this.Session["DomainID"].ToString());
            bt.Domain = FacultyDescription.Text;

            sc.UpdateEmailDomain(bt);

            Response.Redirect("Settings.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
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

        protected void DeleteFaculty(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteEmailDomain(Convert.ToInt32(this.Session["DomainID"].ToString()));
            Response.Redirect("Settings.aspx");
        }

        protected void FacultyDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
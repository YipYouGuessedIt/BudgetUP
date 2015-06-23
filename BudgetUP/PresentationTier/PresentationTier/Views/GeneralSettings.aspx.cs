﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class GeneralSettings : System.Web.UI.Page
    {
        protected void addBursaryType(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();

            Admin_SysSettings bt = new Admin_SysSettings();

            bt.Id = 1;
            bt.EscalationRate = Convert.ToDouble(EscalationRate.Text);
            bt.InstitutionalCost = Convert.ToDouble(InstutionalCost.Text);
            bt.MaximumProjectSpan = Convert.ToInt32(MaximumSpan.Text);
            bt.SubventionRate = Convert.ToDouble(Subvention.Text);

            sc.UpdateAdminSysSettings(bt);

            Response.Redirect("Settings.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (this.Session["Admin"] == "false")
            {
                Response.Redirect("ProjectsPage.aspx");
            }
            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from BursaryTypes
                                in dbContext.Admin_SysSettings
                                select BursaryTypes;


                    foreach (Admin_SysSettings p in query)
                    {
                        if (p.Id.ToString() == "1")
                        {
                            if (!IsPostBack)
                            {
                                EscalationRate.Text = p.EscalationRate.ToString();
                                InstutionalCost.Text = p.InstitutionalCost.ToString();
                                MaximumSpan.Text = p.MaximumProjectSpan.ToString();
                                Subvention.Text = p.SubventionRate.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}
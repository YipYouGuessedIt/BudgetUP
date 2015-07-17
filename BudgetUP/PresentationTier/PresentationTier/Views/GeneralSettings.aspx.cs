using System;
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
            using (var dbContext = new dboEntities())
            {
                ServiceContracts sc = new ServiceContracts();

                Admin_SysSettings bt = new Admin_SysSettings();
                var query2 = from Project_Settings
                                     in dbContext.Admin_SysSettings
                             select Project_Settings;

                int value = query2.Count<Admin_SysSettings>();
                int lastvalue = 1;

                foreach (Admin_SysSettings m in query2)
                {
                    if (lastvalue == value)
                    {
                        bt.Id = m.Id;
                    }
                    lastvalue++;
                }


                bt.EscalationRate = Convert.ToDouble(EscalationRate.Text);
                bt.InstitutionalCost = Convert.ToDouble(InstutionalCost.Text);
                bt.SubventionRate = Convert.ToDouble(Subvention.Text);
                bt.MaximumProjectSpan =Convert.ToInt32( MaximumSpan.Text);

                sc.UpdateAdminSysSettings(bt);

                Response.Redirect("Settings.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
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

                    int value = query.Count<Admin_SysSettings>();
                    int val = 1;
                    foreach (Admin_SysSettings p in query)
                    {
                        if (val.ToString() == value.ToString())
                        {
                            if (!IsPostBack)
                            {
                                EscalationRate.Text = p.EscalationRate.ToString();
                                InstutionalCost.Text = p.InstitutionalCost.ToString();
                                MaximumSpan.Text = p.MaximumProjectSpan.ToString();
                                Subvention.Text = p.SubventionRate.ToString();
                            }
                        }
                        val++;
                    }
                }
            }
        }
    }
}
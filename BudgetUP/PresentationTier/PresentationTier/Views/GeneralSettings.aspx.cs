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
            try
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
                bt.UPFleetDailyRate = Convert.ToInt32(uprate.Text);
                bt.MaximumProjectSpan = Convert.ToInt32(MaximumSpan.Text);
                bt.UPFleetKmRate = Convert.ToDouble(TextBox1.Text);

                sc.UpdateAdminSysSettings(bt);

                Response.Redirect("Settings.aspx");
            }

            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a>  &gt <a href='Settings.aspx'>Settings</a>  &gt General settings";
            try
            {
                //errormsg.Visible = false;
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
            if (this.Session["Admin"].ToString() == "false".ToString())
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
                                TextBox1.Text = p.UPFleetKmRate.ToString();
                                fc.Text = p.FCkmRate.ToString();
                                uprate.Text = p.UPFleetDailyRate.ToString();
                            }
                        }
                        val++;
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
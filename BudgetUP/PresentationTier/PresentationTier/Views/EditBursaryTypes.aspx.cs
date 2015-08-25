using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditBursaryTypes : System.Web.UI.Page
    {
        protected void addBursaryType(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();

            BursaryType bt = new BursaryType();

            bt.Id = Convert.ToInt32(this.Session["BursaryTypeID"].ToString());
            bt.Description = BursaryDescription.Text;
            bt.AnnualCost = Convert.ToDouble(AnnualCost.Text);
            bt.DurationYears = Convert.ToInt32(Years.Text);

            sc.UpdateBursaryType(bt);

            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

                //errormsg.Visible.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);


            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible.Visible = false;
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (Session["BursaryTypeID"] == null)
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
            if (this.Session["BursaryTypeID"] == null)
            {
                Response.Redirect("Settings.aspx");
            }
            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from BursaryTypes
                                in dbContext.BursaryTypes
                                select BursaryTypes;


                    foreach (BursaryType p in query)
                    {
                        if (p.Id.ToString() == Session["BursaryTypeID"].ToString())
                        {
                            if (!IsPostBack)
                            {
                                BursaryDescription.Text = p.Description.ToString();
                                AnnualCost.Text = p.AnnualCost.ToString();
                                Years.Text = p.DurationYears.ToString();
                            }

                        }
                    }

                }
            }
            }
            catch (Exception err)
            {

                //errormsg.Visible.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteBursary(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteBursaryType(Convert.ToInt32(this.Session["BursaryTypeID"].ToString()));
            this.Session["BursaryTypeID"] = null;
            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

                //errormsg.Visible.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                //errormsg.Visible.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditDurationType : System.Web.UI.Page
    {
        protected void addBursaryType(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();

            DurationType bt = new DurationType();

            bt.Id = Convert.ToInt32(this.Session["DurationTypeID"].ToString());
            bt.Description = RoleDescription.Text;

            sc.UpdateDurationType(bt);

            Response.Redirect("Settings.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (this.Session["DurationTypeID"] == null)
            {
                Response.Redirect("Settings.aspx");
            }
            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from BursaryTypes
                                in dbContext.DurationTypes
                                select BursaryTypes;


                    foreach (DurationType p in query)
                    {
                        if (p.Id.ToString() == Session["DurationTypeID"].ToString())
                        {
                            if (!IsPostBack)
                            {
                                RoleDescription.Text = p.Description.ToString();
                            }
                        }
                    }
                }
            }
        }

        protected void DeleteDurationType(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteDurationType(Convert.ToInt32(this.Session["DurationTypeID"].ToString()));
            Response.Redirect("Settings.aspx");
        }
    }
}
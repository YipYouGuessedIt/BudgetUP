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
            ServiceContracts sc = new ServiceContracts();

            BursaryType bt = new BursaryType();

            bt.Id = Convert.ToInt32(this.Session["bursaryTypeID"].ToString());
            bt.Description = BursaryDescription.Text;

            sc.UpdateBursaryType(bt);

            Response.Redirect("Settings.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
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
                            BursaryDescription.Text = p.Description.ToString();
                        }
                    }

                }
            }
        }
    }
}
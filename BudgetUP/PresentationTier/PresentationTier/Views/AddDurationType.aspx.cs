using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class AddDurationType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addRole(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            sc.AddDurationType(DurationName.Text);
            Response.Redirect("Settings.aspx");
        }
    }
}
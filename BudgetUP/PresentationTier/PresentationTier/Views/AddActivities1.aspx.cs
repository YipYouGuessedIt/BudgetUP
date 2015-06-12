using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class AddActivities1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            sc.AddActivity(Convert.ToInt32( Session["ObjectiveID"].ToString()), ActName.Text, Convert.ToDateTime(sdate.Text), Convert.ToDateTime(edate.Text));
        }
    }
}
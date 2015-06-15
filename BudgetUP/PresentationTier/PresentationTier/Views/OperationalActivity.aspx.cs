using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class OperationalActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            int oppID = Convert.ToInt32(this.Session["operationalID"].ToString());
            int expID = Convert.ToInt32(this.Session["ActID"].ToString());// <--CHECK THIS IT MIGHT BE WRONG SESSION VAR
            sc.AddOperation(expID, oppID, Convert.ToInt32(quantity.Text), Convert.ToInt32(amount.Text));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class DonationActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            int noteID = sc.AddNotes(note.Text);
            sc.AddIncome(0/*ProjectID from session variable*/,name.Text,Convert.ToDouble(amount.Text), noteID);
        }
    }
}
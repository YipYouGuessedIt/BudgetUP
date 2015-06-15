using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class BursaryActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            int NoteID = sc.AddNotes(note.Text);
            //get not boxes ID
            int projectID = Convert.ToInt32(this.Session["projectID"].ToString());
            sc.AddBursary(bursaryType.SelectedIndex, projectID, NoteID);
        }
    }
}
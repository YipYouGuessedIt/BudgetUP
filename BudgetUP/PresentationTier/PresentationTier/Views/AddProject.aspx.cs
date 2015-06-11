using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class AddProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddProject_Click(object sender, EventArgs e)
        {
            ServiceContracts project = new ServiceContracts();
            int userID = Convert.ToInt32(this.Session["userID"]);
            project.AddProject(userID, title.Text, goal.Text,Convert.ToInt32(length.Text), Convert.ToInt32(lengthType.Text), 0);
        }
    }
}
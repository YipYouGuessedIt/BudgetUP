using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class BursaryActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            int NoteID = sc.AddNotes(note.Text);
            int projectID = Convert.ToInt32(this.Session["projectID"].ToString());
            sc.AddBursary(bursaryType.SelectedIndex, projectID, NoteID);
        }

        protected void bursaryType_Init(object sender, EventArgs e)
        {
            bursaryType.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from BursaryTypes
                            in dbContext.BursaryTypes
                            select BursaryTypes;

                foreach (BursaryType p in query)
                {
                    // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    bursaryType.Items.Add(m);
                }

            }
        }
    }
}
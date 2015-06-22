using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class OperationalActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            int noteID = sc.AddNotes(note.Text);
            int actID = Convert.ToInt32(this.Session["ActID"].ToString());
            int expID = sc.AddExpense(actID, Convert.ToInt32(quantity.Text) * Convert.ToDouble(amount.Text), noteID);            
            sc.AddOperation(expID, oppType.SelectedIndex, Convert.ToInt32(quantity.Text), Convert.ToDouble(amount.Text));
        }

        protected void oppType_Init(object sender, EventArgs e)
        {
            oppType.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from Operation_Type
                            in dbContext.Operation_Type
                            select Operation_Type;

                foreach (Operation_Type p in query)
                {
                    // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    oppType.Items.Add(m);
                }

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class Personelactivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
        }

        private void AddPersonnel1(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            int noteID = sc.AddNotes(note.Text);
            int expID = sc.AddExpense(Convert.ToInt32(Session["ActID"].ToString()), Convert.ToDouble(Amount.Text), noteID);
            sc.AddUPStaffMember(Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(numofdays.Text), Convert.ToBoolean(DropDownList1.SelectedIndex), expID);
            Response.Redirect("IncomeandExpensesPage.aspx");
        }

        protected void DropDownList2_Init(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from PostLevels
                            in dbContext.PostLevels
                            select PostLevels;

                foreach (PostLevel p in query)
                {
                    // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    DropDownList2.Items.Add(m);
                }

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            int noteID = sc.AddNotes(note.Text);
            int expID = sc.AddExpense(Convert.ToInt32(Session["ActID"].ToString()), Convert.ToDouble(Amount.Text), noteID);
            sc.AddUPStaffMember(DropDownList2.SelectedIndex, Convert.ToInt32(numofdays.Text), Convert.ToBoolean(DropDownList1.SelectedIndex), expID);
            Response.Redirect("IncomeandExpensesPage.aspx");
        }
    }
}
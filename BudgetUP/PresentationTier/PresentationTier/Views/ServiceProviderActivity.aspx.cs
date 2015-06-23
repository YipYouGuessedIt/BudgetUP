using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PresentationTier.Views
{
    public partial class ServiceProviderActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            int noteID = sc.AddNotes(note.Text);
            int expID = sc.AddExpense(Convert.ToInt32(Session["ActID"].ToString()), Convert.ToDouble(amount.Text), noteID);
            sc.AddContractor(name.Text, expID);
            Response.Redirect("IncomeandExpensesPage.aspx");
        }
    }
}
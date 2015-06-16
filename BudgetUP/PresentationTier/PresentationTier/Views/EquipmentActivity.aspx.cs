using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class EquipmentActivity : System.Web.UI.Page
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
            //try
            //{
                ServiceContracts sc = new ServiceContracts();
                int noteID = sc.AddNotes(note.Text);
                int ActID = Convert.ToInt32(this.Session["ActID"].ToString());
                int ExpenseID = sc.AddExpense(ActID, Convert.ToDouble(amount.Text), noteID);
                sc.AddEquipment(name.Text, ExpenseID);
            //}
            //catch(Exception f)
            //{
               
            //}
        }
    }
}
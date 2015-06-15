using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewServiceProvider : System.Web.UI.Page
    {
        int expid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["contractorID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Contractors
                            select Projects;


                foreach (Contractor p in query)
                {
                    if (p.Id.ToString() == Session["contractorID"].ToString())
                    {
                        name.Text = p.ContractorName;
                        amount.Text = p.Expens.Amount.ToString();
                        note.Text = p.Expens.Note.UserNote;
                        expid = p.Expense_Id;
                    }
                }

            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            ServiceContracts m = new ServiceContracts();
            Expens em = new Expens();
            Contractor c = new Contractor();
            c.Id = Convert.ToInt32(Session["contractorID"].ToString());
            c.ContractorName = name.Text;
            c.Expense_Id = expid;
            m.UpdateContractor(c);
            em.Id = expid;
            em.Amount = Convert.ToInt32(amount.Text);
            em.ActivityId = Convert.ToInt32(Session["ActID"].ToString());
            em.Note_Id = 1;
            m.UpdateExpense(em);
        }
    }
}
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
        internal int expid = 0;
        internal int notede = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errormsg.Visible = false;
            if (Session["contractorID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }

            if (this.Session["Admin"].ToString() == "True".ToString())
            {
                adminnav.Visible = true;
                normalnav.Visible = false;
            }
            else
            {
                adminnav.Visible = false;
                normalnav.Visible = true;
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
                        if (!IsPostBack)
                        {
                            name.Text = p.ContractorName;
                            amount.Text = p.Expens.Amount.ToString();
                            note.Text = p.Expens.Note.UserNote;

                        }
                        expid = p.Expense_Id;
                        notede = p.Expens.Note_Id;
                    }
                }

            }
                        }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            try
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
            em.Note_Id = notede;
            Note no = new Note();
            no.Id = notede;
            no.UserNote = note.Text;
            m.UpdateNotes(no);
            m.UpdateExpense(em);
            Response.Redirect("IncomeandExpensesPage.aspx");
                        }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                errormsg.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceContracts m = new ServiceContracts();
                m.DeleteContractor(Convert.ToInt32(this.Session["contractorID"].ToString()));
                this.Session["contractorID"] = null;
                Response.Redirect("IncomeandExpensesPage.aspx");
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }
    }
}
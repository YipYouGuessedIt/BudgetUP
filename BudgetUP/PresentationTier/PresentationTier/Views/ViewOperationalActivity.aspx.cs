using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewOperationalActivity : System.Web.UI.Page
    {
        private int expid = 0;
        int notede = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
            if (Session["operationalID"] == null)
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
                            in dbContext.Operationals
                            select Projects;




                foreach (Operational p in query)
                {
                    if (p.Id.ToString() == Session["operationalID"].ToString())
                    {
                        if (!IsPostBack)
                        {
                            DropDownList1.SelectedValue = p.Operation_TypeId.ToString();
                            amount.Text = p.PricePerUnit.ToString();
                            quantity.Text = p.Quantity.ToString();
                            note.Text = p.Expens.Note.UserNote;

                        }
                        notede = p.Expens.Note_Id;
                        expid = p.Expense_Id;
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

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            try
            { 
            ServiceContracts m = new ServiceContracts();
            Expens em = new Expens();
            Operational c = new Operational();
            c.Id = Convert.ToInt32(Session["operationalID"].ToString());
            c.Operation_TypeId = Convert.ToInt32( DropDownList1.SelectedItem.Value);
            c.Expense_Id = expid;
            c.Quantity = Convert.ToInt32(quantity.Text);
            c.PricePerUnit = Convert.ToInt32(amount.Text);
            m.UpdateOperation(c);
            em.Id = expid;
            em.Amount = Convert.ToInt32(Convert.ToInt32(amount.Text) * Convert.ToInt32(quantity.Text));
            em.ActivityId = Convert.ToInt32(Session["ActID"].ToString());
            em.Note_Id = notede;
            Note no = new Note();
            no.Id = notede;
            no.UserNote = note.ToString();
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

        protected void DropDownList1_Init(object sender, EventArgs e)
        {
            try
            { 
            DropDownList1.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Operation_Type
                            select Projects;

                foreach (Operation_Type p in query)
                {
                    
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    DropDownList1.Items.Add(m);
                }

            }
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
                m.DeleteOperation(Convert.ToInt32(this.Session["operationalID"].ToString()));
                this.Session["operationalID"] = null;
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
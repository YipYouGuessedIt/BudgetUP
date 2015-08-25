using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewCar : System.Web.UI.Page
    {


        private int expid = 0;
        int notede = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible = false;
            if (Session["car"] == null)
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
                            in dbContext.Cars
                            select Projects;


                foreach (Car p in query)
                {
                    if (p.Id.ToString() == Session["car"].ToString())
                    {
                        if (!IsPostBack)
                        {
                            
                            fleet.SelectedValue = p.TypeofRental.ToString();
                            TextBox1.Text = p.Kilometers.ToString();
                            quantity.Text = p.Days.ToString();
                            quantity.Text = p.Expen.Amount.ToString();
                            note.Text = p.Expen.Note.UserNote;

                        }
                        expid = p.ExpensId;
                        notede = p.Expen.Note_Id;
                    }
                }

            }
            tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt <a href='ObjectivesPage.aspx'>Project Details and Objective List</a> &gt <a href='ActivitiesPage.aspx'>Objective Details and Activity List</a> &gt <a href='IncomeandExpensesPage.aspx'>Activity Details</a> &gt  Edit Travel";

                        }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            try
            {
            Car c = new Car();
            Expens ex = new Expens();
            c.Id = Convert.ToInt32(Session["car"].ToString());
            c.TypeofRental = Convert.ToInt32(fleet.SelectedValue);
            c.Kilometers = Convert.ToInt32(TextBox1.Text);
            c.Days = Convert.ToInt32(quantity.Text);
            c.ExpensId = expid;
            ex.Note_Id = notede;
            ex.Id = expid;
            ex.Amount = Convert.ToDouble( quantity.Text);
            Note no = new Note();
            no.Id = notede;
            no.UserNote = note.Text;
            ex.ActivityId = Convert.ToInt32(Session["ActID"].ToString());
            ServiceContracts con = new ServiceContracts();
            con.UpdateNotes(no);
            con.UpdateExpense(ex);
            con.UpdateCarExpense(c);
            Response.Redirect("IncomeandExpensesPage.aspx");
                        }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceContracts m = new ServiceContracts();
                m.DeleteCarExpense(Convert.ToInt32(this.Session["car"].ToString()));
                this.Session["car"] = null;
                Response.Redirect("IncomeandExpensesPage.aspx");
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }
    }
}
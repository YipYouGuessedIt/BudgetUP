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
                            
                            fleet.SelectedValue = Convert.ToBoolean(p.UPFleet).ToString();;
                            quantity.Text = p.Expen.Amount.ToString();
                            note.Text = p.Expen.Note.UserNote;

                        }
                        expid = p.ExpensId;
                        notede = p.Expen.Note_Id;
                    }
                }

            }
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            Car c = new Car();
            Expens ex = new Expens();
            c.Id = Convert.ToInt32(Session["car"].ToString());
            c.UPFleet = Convert.ToBoolean(fleet.SelectedIndex);
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
        }
    }
}
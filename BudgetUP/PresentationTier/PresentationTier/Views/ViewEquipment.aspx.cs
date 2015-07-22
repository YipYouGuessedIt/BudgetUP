using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewEquipment : System.Web.UI.Page
    {
        private int expid = 0;
        int notede = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["equipID"] == null)
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
                            in dbContext.Equipments
                            select Projects;


                foreach (Equipment p in query)
                {
                    if (p.Id.ToString() == Session["equipID"].ToString())
                    {
                        if (!IsPostBack)
                        {
                            name.Text = p.EquipmentName;
                            amount.Text = p.Expens.Amount.ToString();
                            note.Text = p.Expens.Note.UserNote;
                            
                        }
                        expid = p.Expense_Id;
                        notede = p.Expens.Note_Id;
                    }
                }

            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            ServiceContracts m = new ServiceContracts();
            Expens em = new Expens();
            Equipment c = new Equipment();
            c.Id = Convert.ToInt32(Session["equipID"].ToString());
            c.EquipmentName = name.Text;
            c.Expense_Id = expid;
            m.UpdateEquipment(c);
            em.Id = expid;
            em.Amount = Convert.ToInt32(amount.Text);
            em.ActivityId = Convert.ToInt32(Session["ActID"].ToString());
            em.Note_Id = notede;
            Note no = new Note();
            no.Id = notede;
            no.UserNote = note.Text.ToString();
            m.UpdateNotes(no);
            m.UpdateExpense(em);


        }
    }
}
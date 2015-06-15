using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewPersonalActivity : System.Web.UI.Page
    {
        int expid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UPstaffID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.UPStaffMembers
                            select Projects;


                foreach (UPStaffMember p in query)
                {
                    if (p.Id.ToString() == Session["UPstaffID"].ToString())
                    {
                        expid = p.Expense_Id;
                        amount.Text = p.Expens.Amount.ToString();
                        DropDownList2.SelectedValue = p.PostLevelId.ToString();
                        DropDownList1.SelectedValue = Convert.ToInt32( p.SubventionLevy).ToString();
                        numofdays.Text = p.DaysInvolved.ToString();
                        note.Text = p.Expens.Note.UserNote;
                    }
                }

            }
        }

        protected void DropDownList2_Init(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Roles
                            select Projects;

                foreach (Role p in query)
                {
                    // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    DropDownList2.Items.Add(m);
                }

            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            ServiceContracts m = new ServiceContracts();
            Expens em = new Expens();
            UPStaffMember c = new UPStaffMember();
            c.Id = Convert.ToInt32(Session["UPstaffID"].ToString());
            c.SubventionLevy = Convert.ToBoolean( DropDownList1.SelectedValue);
            c.PostLevelId = Convert.ToInt32(DropDownList2.SelectedValue);
            c.Expense_Id = expid;
            m.UpdateUPStaffMember(c);
            em.Id = expid;
            em.Amount = Convert.ToInt32(amount.Text);
            em.ActivityId = Convert.ToInt32(Session["ActID"].ToString());
            em.Note_Id = 1;
            m.UpdateExpense(em);
        }
    }
}
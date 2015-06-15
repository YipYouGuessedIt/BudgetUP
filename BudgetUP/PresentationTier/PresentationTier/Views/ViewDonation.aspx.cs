using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewDonation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IncID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }

            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Incomes
                            select Projects;


                foreach (Income p in query)
                {
                    if (p.Id.ToString() == Session["IncID"].ToString())
                    {
                        name.Text = p.DonorName;
                        amount.Text = p.Amount.ToString();
                        note.Text = p.Note.UserNote;
                    }
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceContracts m = new ServiceContracts();
            Income n = new Income();
            n.Id = Convert.ToInt32(Session["IncID"]);
            n.ProjectId = Convert.ToInt32(Session["ProjectID"]);
            n.Amount = Convert.ToInt32(amount.Text);
            n.DonorName = name.Text;
            n.Note_Id = 2;
        }
    }
}
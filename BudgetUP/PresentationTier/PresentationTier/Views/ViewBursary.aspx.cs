using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewBursary : System.Web.UI.Page
    {
        int notede = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["BursIDID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }
            
                using (var dbContext = new dboEntities())
                {
                    var query = from Projects
                                in dbContext.Bursaries
                                select Projects;


                    foreach (Bursary p in query)
                    {
                        if (p.Id.ToString() == Session["BursIDID"].ToString())
                        {
                            Years.Text = p.BursaryType.DurationYears.ToString();
                            Cost.Text = p.BursaryType.AnnualCost.ToString();
                            
                           DropDownList2.SelectedValue = p.BursaryTypeId.ToString();
                            note.Text = p.Note.UserNote;
                            notede = p.Note_Id;
                        }
                    }

                }
               
            //}
        }

        protected void loader()
        {
            DropDownList2.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.BursaryTypes
                            select Projects;

                foreach (BursaryType p in query)
                {
                   // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    DropDownList2.Items.Add(m);
                }

            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
 

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
           // Response.Write(DropDownList2.SelectedValue + DropDownList2.SelectedItem);
            ServiceContracts m = new ServiceContracts();
            Bursary n = new Bursary();
            n.Id = Convert.ToInt32( Session["BursIDID"].ToString());

            n.BursaryTypeId = Convert.ToInt32( DropDownList2.SelectedItem.Value);
            n.ProjectId = Convert.ToInt32(Session["ProjectID"]);
            n.Note_Id = notede;
            Note no = new Note();
            no.Id = notede;
            no.UserNote = note.ToString();
            m.UpdateNotes(no);
            //Response.Write("<script>alert('"+ n.BursaryTypeId +"');</script>");
            m.UpdateBursary(n);
        }

        protected void DropDownList2_Init(object sender, EventArgs e)
        {
            this.loader();
        }
    }
}
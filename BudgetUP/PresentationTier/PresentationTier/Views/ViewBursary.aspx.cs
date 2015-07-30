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
            try
            {
                errormsg.Visible = false;
            
            if (Session["BursIDID"] == null)
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
                                in dbContext.Bursaries
                                select Projects;


                    foreach (Bursary p in query)
                    {
                        if (p.Id.ToString() == Session["BursIDID"].ToString())
                        {

                            if (!IsPostBack)
                            {

                                DropDownList2.SelectedValue = p.BursaryTypeId.ToString();
                                sdate.Text = p.StartDate.Date.ToString("yyyy-MM-dd");
                                note.Text = p.Note.UserNote;   
                            }
                            notede = p.Note_Id;
                        }
                    }

                }

            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }   
            //}
        }

        protected void loader()
        {
            try
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
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
 

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            try
            {
           Response.Write(DropDownList2.SelectedValue + DropDownList2.SelectedItem);
            ServiceContracts m = new ServiceContracts();
            Bursary n = new Bursary();
            n.Id = Convert.ToInt32( Session["BursIDID"].ToString());

            n.BursaryTypeId = Convert.ToInt32( DropDownList2.SelectedItem.Value);
            n.ProjectId = Convert.ToInt32(Session["ProjectID"].ToString());
            n.Note_Id = notede;
            n.StartDate = Convert.ToDateTime(sdate.Text);
            Note no = new Note();
            no.Id = notede;
            no.UserNote = note.Text.ToString();
            m.UpdateNotes(no);
            //Response.Write("<script>alert('"+ n.BursaryTypeId +"');</script>");
            m.UpdateBursary(n);
            Response.Redirect("IncomeandExpensesPage.aspx");
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void DropDownList2_Init(object sender, EventArgs e)
        {
            try
            { 
            this.loader();
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
                m.DeleteBursary(Convert.ToInt32(this.Session["BursIDID"].ToString()));
                this.Session["BursIDID"] = null;
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
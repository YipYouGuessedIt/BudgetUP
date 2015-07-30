using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class BursaryActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errormsg.Visible = false;
            if (Session.Count == 0)
            {
               
                    errormsg.Visible = false;
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (Session["projectID"] == null)
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
                using (var dbContext = new dboEntities())
                {
                    var query2 = from Project
                                         in dbContext.Projects
                                 select Project;

                    foreach (Project m in query2)
                    {
                        if (m.Id.ToString() == Session["projectID"].ToString())
                        {
                            int n = Convert.ToInt32(bursaryType.SelectedValue);
                            var query = dbContext.BursaryTypes.Where(b => b.Id == n ).FirstOrDefault();
                            if (query != null)
                            {
                                DateTime start = Convert.ToDateTime(sdate.Text);
                                
                                start.AddYears(query.DurationYears);
                                if (m.EndDate > start)
                                {
                                    ServiceContracts sc = new ServiceContracts();
                                    int NoteID = sc.AddNotes(note.Text);
                                    int projectID = Convert.ToInt32(this.Session["projectID"].ToString());
                                    sc.AddBursary(Convert.ToInt32(bursaryType.SelectedValue), projectID, NoteID, Convert.ToDateTime(sdate.Text));
                                    Response.Redirect("IncomeandExpensesPage.aspx");
                                }
                                else
                                {
                                    errormsg.Visible = true;
                                    messageforerror.Text = "End date is befor start date";
                                }
                            }

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

        protected void bursaryType_Init(object sender, EventArgs e)
        {
            try
            {
            bursaryType.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from BursaryTypes
                            in dbContext.BursaryTypes
                            select BursaryTypes;

                foreach (BursaryType p in query)
                {
                    // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    bursaryType.Items.Add(m);
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
    }
}
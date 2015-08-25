using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class TravelActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.MaintainScrollPositionOnPostBack = true;
                //errormsg.Visible = false;
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (Session.Count == 0)
            {

                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }

            if (this.Session["ActID"] == null)
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
            if (!IsPostBack)
            {
                sdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

               
            }
            tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt <a href='ObjectivesPage.aspx'>Project Details and Objective List</a> &gt <a href='ActivitiesPage.aspx'>Objective Details and Activity List</a> &gt <a href='IncomeandExpensesPage.aspx'>Activity Details</a> &gt  Add Travel";

            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);


            }
        }

        protected void oppType_Init(object sender, EventArgs e)
        {
            
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            //try
            //{
                bool mi = checkdate();
                if (mi == true)
                {
                    int actID = Convert.ToInt32(Session["ActID"].ToString());
                    ServiceContracts sc = new ServiceContracts();
                    int noteID = sc.AddNotes(note.Text.ToString());

                    //double amounts = Convert.ToDouble(AccommodationAmount.Text);
                    //amounts += Convert.ToDouble(AirlineAmount.Text);
                    //amounts += Convert.ToDouble(AllowanceAmount.Text);
                    //amounts += Convert.ToDouble(gautrainAmount.Text);
                    //amounts += Convert.ToDouble(visaAmount.Text);
                    double amounts = 0;
                    int expID = sc.AddExpense(actID, amounts, noteID);

                    int travelID = sc.AddTravel(0, Convert.ToInt32(numofdays.Text), Convert.ToDateTime(sdate.Text), destination.Text, expID, destination0.Text,name.Text);
                    if (fleet.SelectedIndex == 0)
                    {
                        sc.AddVisaExpense(0, travelID);
                    }
                    if (fleet0.SelectedIndex == 0)
                    {
                        sc.AddGautrainExpense(0, travelID);
                    }
                    if (fleet1.SelectedIndex == 0)
                    {
                        sc.AddAllowance(0, travelID);
                    }
                    if (fleet11.SelectedIndex == 0)
                    {
                        sc.AddAirline(Convert.ToBoolean(returnTicket.SelectedIndex), 0, travelID);
                    }
                    if (fleet3.SelectedIndex == 0)
                    {
                        sc.AddAccommodation(0, travelID);
                    }
                    Response.Redirect("IncomeandExpensesPage.aspx");
                }
                else
                {
                    //errormsg.Visible = true;
                    messageforerror.InnerHtml ="Date of departure is out of bounds of the Activity";
                    ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

                }
//}
//            catch (Exception err)
//            {

//                //errormsg.Visible = true;
//                messageforerror.InnerHtml = Class1.genericErr;
//                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

//            }            
            
        }

        protected void Alerter()
        {
            
        }

        protected bool checkdate()
        {
            using (var dbContext = new dboEntities())
            {
                int n = Convert.ToInt32(Session["ActID"].ToString());
                var query = dbContext.Activities.Where(b => b.Id == n).FirstOrDefault();
                if (query == null)
                    return false;

                if (query.StartDate < Convert.ToDateTime(sdate.Text) || query.EndDate > Convert.ToDateTime(sdate.Text))
                {
                    return true;
                }
                return false;
            }
        }

        protected void fleet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnTicket.SelectedValue = (1).ToString();
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

        protected void fleet2_TextChanged(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('works');</script>");
        }

        protected void name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
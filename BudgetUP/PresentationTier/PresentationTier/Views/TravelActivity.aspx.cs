using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class TravelActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        protected void oppType_Init(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
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
            int expID = sc.AddExpense(actID,amounts,noteID);

            int travelID = sc.AddTravel(0, Convert.ToInt32(numofdays.Text), Convert.ToDateTime(sdate.Text), destination.Text, expID,destination0.Text);
            if(fleet.SelectedIndex == 0)
            {
                sc.AddVisaExpense(0, travelID);
            }
            if(fleet0.SelectedIndex == 0)
            {
                sc.AddGautrainExpense(0, travelID);
            }
            if(fleet1.SelectedIndex == 0)
            {
                sc.AddAllowance(0, travelID);
            }
            if (fleet2.SelectedIndex == 0)
            {
                sc.AddAirline(Convert.ToBoolean(returnTicket.SelectedIndex), 0, travelID);
            }
            if (fleet3.SelectedIndex == 0)
            {
                sc.AddAccommodation(0, travelID);
            }
            
            
            
        }
    }
}
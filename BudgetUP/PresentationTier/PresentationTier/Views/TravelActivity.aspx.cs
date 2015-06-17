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
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            int actID = Convert.ToInt32(Session["ActID"].ToString());
            ServiceContracts sc = new ServiceContracts();
            int noteID = sc.AddNotes(note.ToString());

            double amounts = Convert.ToDouble(AccommodationAmount.Text);
            amounts += Convert.ToDouble(AirlineAmount.Text);
            amounts += Convert.ToDouble(AllowanceAmount.Text);
            amounts += Convert.ToDouble(CarAmount.Text);
            amounts += Convert.ToDouble(gautrainAmount.Text);
            amounts += Convert.ToDouble(visaAmount.Text);

            int expID = sc.AddExpense(actID,amounts,noteID);

            int travelID = sc.AddTravel(Convert.ToInt32(numoftrav.Text), Convert.ToInt32(numofdays.Text), Convert.ToDateTime(sdate.Text), destination.Text, expID);
            sc.AddVisaExpense(Convert.ToDouble(visaAmount.Text), travelID);
            sc.AddGautrainExpense(Convert.ToDouble(gautrainAmount.Text), travelID);
            sc.AddCarExpense(Convert.ToBoolean(UPFleet.SelectedIndex),Convert.ToDouble(CarAmount.Text), travelID);
            sc.AddAllowance(Convert.ToDouble(AllowanceAmount.Text), travelID);
            sc.AddAirline(Convert.ToBoolean(returnTicket.SelectedIndex), Convert.ToDouble(AllowanceAmount.Text), travelID);
            sc.AddAccommodation(Convert.ToDouble(AccommodationAmount.Text), travelID);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewTravelActivity : System.Web.UI.Page
    {
        int expid = 0;
        int notede = 0;
        int visaid = 0;
        int gaut = 0;
        int acc = 0;
        int car = 0;
        int allow = 0;
        int air = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TravelID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Travels
                            select Projects;


                foreach (Travel p in query)
                {
                    if (p.Id.ToString() == Session["TravelID"].ToString())
                    {
                        numoftrav.Text = p.TravellerNo.ToString();
                        numofdays.Text = p.DurationDays.ToString();
                        sdate.Text = p.DepartureDate.ToString();
                        destination.Text = p.Destination;

                        var entry = dbContext.Visas
                        .Where(ad => ad.Travel_Id == Convert.ToInt32( Session["TravelID"]))
                        .FirstOrDefault();
                        visaid = entry.Id;
                        visaAmount.Text = entry.Amount.ToString();

                        var entry2 = dbContext.Gautrains
                        .Where(ad => ad.Travel_Id == Convert.ToInt32(Session["TravelID"]))
                        .FirstOrDefault();
                        gaut = entry2.Id;
                        gautrainAmount.Text = entry2.Amount.ToString();

                        var entry3 = dbContext.Accommodations
                        .Where(ad => ad.Travel_Id == Convert.ToInt32(Session["TravelID"]))
                        .FirstOrDefault();
                        acc = entry3.Id;
                        AccommodationAmount.Text = entry3.Amount.ToString();

                        var entry4 = dbContext.CarExpenses
                        .Where(ad => ad.Travel_Id == Convert.ToInt32(Session["TravelID"]))
                        .FirstOrDefault();
                        car = entry4.Id;
                        CarAmount.Text = entry4.Amount.ToString();
                        UPFleet.SelectedValue = Convert.ToBoolean( entry4.UP_Fleet).ToString();

                        var entry5 = dbContext.AirlineExpenses
                        .Where(ad => ad.Travel_Id == Convert.ToInt32(Session["TravelID"]))
                        .FirstOrDefault();
                        air = entry5.Id;
                        AirlineAmount.Text = entry5.Amount.ToString();
                        returnTicket.SelectedValue = Convert.ToBoolean(entry5.ReturnTicket).ToString();

                        var entry6 = dbContext.Allowances
                        .Where(ad => ad.Travel_Id == Convert.ToInt32(Session["TravelID"]))
                        .FirstOrDefault();
                        allow = entry6.Id;
                        AllowanceAmount.Text = entry6.Amount.ToString();


                        note.Text = p.Expens.Note.UserNote;
                        expid = p.Expense_Id;
                        notede = p.Expens.Note_Id;
                        
                    }
                }

            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {

        }
    }
}
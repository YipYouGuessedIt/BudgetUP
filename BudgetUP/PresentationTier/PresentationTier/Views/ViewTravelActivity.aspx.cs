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
                    int i = Convert.ToInt32(Session["TravelID"].ToString());
                    if (p.Id.ToString() == Session["TravelID"].ToString())
                    {

                        
                        var entry = dbContext.Visas
                        .Where(ad => ad.Travel_Id == 1)
                        .FirstOrDefault();
                        if(entry != null)
                        visaid = entry.Id;

                        var entry2 = dbContext.Gautrains
                        .Where(ad => ad.Travel_Id == i)
                        .FirstOrDefault();
                        if (entry2 != null)
                        gaut = entry2.Id;

                        var entry3 = dbContext.Accommodations
                        .Where(ad => ad.Travel_Id == i)
                        .FirstOrDefault();
                        if (entry3 != null)
                        acc = entry3.Id;

                        var entry4 = dbContext.CarExpenses
                        .Where(ad => ad.Travel_Id == i)
                        .FirstOrDefault();
                        if (entry4 != null)
                        car = entry4.Id;

                        var entry5 = dbContext.AirlineExpenses
                        .Where(ad => ad.Travel_Id == i)
                        .FirstOrDefault();
                        if (entry5 != null)
                        air = entry5.Id;

                        var entry6 = dbContext.Allowances
                        .Where(ad => ad.Travel_Id == i)
                        .FirstOrDefault();
                        if (entry6 != null)
                        allow = entry6.Id;
                        if (!IsPostBack)
                        {
                            numoftrav.Text = p.TravellerNo.ToString();
                            numofdays.Text = p.DurationDays.ToString();
                            sdate.Text = p.DepartureDate.Date.ToString();
                            destination.Text = p.Destination;
                            if (entry != null)
                            visaAmount.Text = entry.Amount.ToString();
                            if (entry2 != null)
                            gautrainAmount.Text = entry2.Amount.ToString();

                            if (entry3 != null)
                            AccommodationAmount.Text = entry3.Amount.ToString();

                            if (entry4 != null)
                            {
                                CarAmount.Text = entry4.Amount.ToString();
                                UPFleet.SelectedValue = Convert.ToBoolean(entry4.UP_Fleet).ToString();
                            }

                            if (entry5 != null)
                            {
                                AirlineAmount.Text = entry5.Amount.ToString();
                                returnTicket.SelectedValue = Convert.ToBoolean(entry5.ReturnTicket).ToString();
                            }
                            if (entry6 != null)
                            AllowanceAmount.Text = entry6.Amount.ToString();


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
            if (expid == 0 || notede == 0 || visaid == 0 || gaut == 0 || acc == 0 || car == 0 || allow == 0 || air == 0)
            {

            }
            else
            {
                ServiceContracts m = new ServiceContracts();
                Travel t = new Travel();
                t.Id = Convert.ToInt32(Session["TravelID"].ToString());
                t.TravellerNo = Convert.ToInt32(numoftrav.Text);
                t.Expense_Id = expid;
                t.DurationDays = Convert.ToInt32(numofdays.Text);
                t.DepartureDate = Convert.ToDateTime(sdate.Text);
                t.Destination = destination.Text;
                m.UpdateTravel(t);

                Visa v = new Visa();
                v.Id = visaid;
                v.Amount = Convert.ToInt32(visaAmount.Text);
                v.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                m.UpdateVisaExpense(v);

                Gautrain g = new Gautrain();
                g.Id = gaut;
                g.Amount = Convert.ToInt32(gautrainAmount.Text);
                g.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                m.UpdateGautrainExpense(g);

                CarExpens c = new CarExpens();
                c.Id = car;
                c.Amount = Convert.ToInt32(CarAmount.Text);
                c.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                c.UP_Fleet = Convert.ToBoolean(Convert.ToInt32(UPFleet.SelectedValue));
                m.UpdateCarExpense(c);

                Allowance a = new Allowance();
                a.Id = allow;
                a.Amount = Convert.ToInt32(AllowanceAmount.Text);
                a.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                m.UpdateAllowance(a);

                AirlineExpens ai = new AirlineExpens();
                ai.Id = air;
                ai.Amount = Convert.ToInt32(AirlineAmount.Text);
                ai.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                ai.ReturnTicket = Convert.ToBoolean(Convert.ToInt32(returnTicket.SelectedValue));
                m.UpdateAirline(ai);

                Accommodation ac = new Accommodation();
                ac.Id = acc;
                ac.Amount = Convert.ToInt32(AccommodationAmount.Text);
                ac.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                m.UpdateAccomodation(ac);

                Expens ex = new Expens();
                ex.Id = expid;
                ex.ActivityId = Convert.ToInt32(Session["ActID"].ToString());
                ex.Amount = Convert.ToInt32(AccommodationAmount.Text) + Convert.ToInt32(AirlineAmount.Text) + Convert.ToInt32(AllowanceAmount.Text) + Convert.ToInt32(CarAmount.Text) + Convert.ToInt32(gautrainAmount.Text) + Convert.ToInt32(visaAmount.Text);
            }
        }
    }
}
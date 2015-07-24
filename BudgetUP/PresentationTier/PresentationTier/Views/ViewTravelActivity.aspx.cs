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
        int visaid2 = 0;
        int gaut2 = 0;
        int acc2 = 0;
        int car2 = 0;
        int allow2 = 0;
        int air2 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errormsg.Visible = false;
            if (Session["TravelID"] == null)
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

                        //var entry4 = dbContext.CarExpenses
                        //.Where(ad => ad.Travel_Id == i)
                        //.FirstOrDefault();
                        //if (entry4 != null)
                        //car = entry4.Id;

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
                           // numoftrav.Text = p.TravellerNo.ToString();
                            numofdays.Text = p.DurationDays.ToString();
                            sdate.Text = p.DepartureDate.Date.ToString("yyyy-MM-dd");
                            destination.Text = p.Destination;
                            destination0.Text = p.DepatureLocation;
                            if (entry != null)
                            {
                                fleet4.SelectedIndex = 0;
                                visaid2 = 1;
                            }
                            else
                            {
                                fleet4.SelectedIndex = 1;
                            }
                            //visaAmount.Text = entry.Amount.ToString();
                            if (entry2 != null)
                            {
                                fleet3.SelectedIndex = 0;
                                gaut2 = 1;
                            }
                            else
                            {
                                fleet3.SelectedIndex = 1;
                            }
                           // gautrainAmount.Text = entry2.Amount.ToString();

                            if (entry3 != null)
                            {
                                
                                fleet0.SelectedIndex = 0;
                                acc2 = 1;
                            }
                            else
                            {
                                fleet0.SelectedIndex = 1;
                            }
                           // AccommodationAmount.Text = entry3.Amount.ToString();

                            //if (entry4 != null)
                            //{
                            //    CarAmount.Text = entry4.Amount.ToString();
                            //    UPFleet.SelectedValue = Convert.ToBoolean(entry4.UP_Fleet).ToString();
                            //}

                            if (entry5 != null)
                            {
                                air2 = 1;
                                fleet11.SelectedIndex = 0;
                                returnTicket.SelectedIndex = Convert.ToInt32(entry5.ReturnTicket);
                            }
                            else
                            {
                                fleet11.SelectedIndex = 1;
                            }
                            if (entry6 != null)
                            {
                                fleet2.SelectedIndex = 0;
                                allow2 = 1;
                            }
                            else
                            {
                                fleet2.SelectedIndex = 1;
                            }


                            note.Text = p.Expens.Note.UserNote;

                        }
                        expid = p.Expense_Id;
                        notede = p.Expens.Note_Id;

                        
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

        protected void oppType_Init(object sender, EventArgs e)
        {
           
        }
        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            //if (expid == 0 || notede == 0 || visaid == 0 || gaut == 0 || acc == 0 || car == 0 || allow == 0 || air == 0)
            //{

            //}
            //else
            //{
            try
            {
                ServiceContracts m = new ServiceContracts();
                Travel t = new Travel();
                t.Id = Convert.ToInt32(Session["TravelID"].ToString());
                //t.TravellerNo = Convert.ToInt32(numoftrav.Text);
                t.Expense_Id = expid;
                t.DurationDays = Convert.ToInt32(numofdays.Text);
                t.DepartureDate = Convert.ToDateTime(sdate.Text);
                t.Destination = destination.Text;
                t.DepatureLocation = destination0.Text;
                m.UpdateTravel(t);

                if(fleet4.SelectedIndex == 0)
                {
                    if(visaid2 == 1)
                    {

                    }
                    else
                    {
                        m.AddVisaExpense(0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                else
                {
                    if (visaid2 == 1)
                    {
                        m.DeleteVisaExpense(visaid);
                    }
                    else
                    {
                        //m.AddVisaExpense(0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                if (fleet3.SelectedIndex == 0)
                {
                    if (gaut2 == 1)
                    {

                    }
                    else
                    {
                        m.AddGautrainExpense(0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                else
                {
                    if (gaut2 == 1)
                    {
                        m.DeleteGautrainExpense(gaut);
                    }
                    else
                    {
                        //m.AddVisaExpense(0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                if (fleet2.SelectedIndex == 0)
                {
                    if (allow2 == 1)
                    {

                    }
                    else
                    {
                        m.AddAllowance(0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                else
                {
                    if (allow2 == 1)
                    {
                        m.DeleteAllowance(allow);
                    }
                    else
                    {
                        //m.AddVisaExpense(0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                if (fleet11.SelectedIndex == 0)
                {
                    if (air2 == 1)
                    {
                        AirlineExpens ai = new AirlineExpens();
                        ai.Id = air;
                        //ai.Amount = Convert.ToInt32(AirlineAmount.Text);
                        ai.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                        ai.ReturnTicket = Convert.ToBoolean(Convert.ToInt32(returnTicket.SelectedValue));
                        m.UpdateAirline(ai);
                    }
                    else
                    {
                        m.AddAirline(Convert.ToBoolean( returnTicket.SelectedIndex),0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                else
                {
                    if (air2 == 1)
                    {
                        m.DeleteAirline(air);
                    }
                    else
                    {
                        //m.AddVisaExpense(0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                if (fleet0.SelectedIndex == 0)
                {
                    if (acc2 == 1)
                    {

                    }
                    else
                    {
                        m.AddAccommodation(0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                else
                {
                    if (acc2 == 1)
                    {
                        m.DeleteAccommodation(acc);
                    }
                    else
                    {
                        //m.AddVisaExpense(0, Convert.ToInt32(Session["TravelID"].ToString()));
                    }
                }
                //Visa v = new Visa();
                //v.Id = visaid;
                //v.Amount = Convert.ToInt32(visaAmount.Text);
                //v.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                //m.UpdateVisaExpense(v);

                //Gautrain g = new Gautrain();
                //g.Id = gaut;
                //g.Amount = Convert.ToInt32(gautrainAmount.Text);
                //g.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                //m.UpdateGautrainExpense(g);

                //CarExpens c = new CarExpens();
                //c.Id = car;
                //c.Amount = Convert.ToInt32(CarAmount.Text);
                //c.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                //c.UP_Fleet = Convert.ToBoolean(Convert.ToInt32(UPFleet.SelectedValue));
                //m.UpdateCarExpense(c);

                //Allowance a = new Allowance();
                //a.Id = allow;
                //a.Amount = Convert.ToInt32(AllowanceAmount.Text);
                //a.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                //m.UpdateAllowance(a);



                //Accommodation ac = new Accommodation();
                //ac.Id = acc;
                //ac.Amount = Convert.ToInt32(AccommodationAmount.Text);
                //ac.Travel_Id = Convert.ToInt32(Session["TravelID"].ToString());
                //m.UpdateAccomodation(ac);

                Expens ex = new Expens();
                ex.Id = expid;
                ex.ActivityId = Convert.ToInt32(Session["ActID"].ToString());
                ex.Amount = 0;
                Response.Redirect("IncomeandExpensesPage.aspx");
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
            //}
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
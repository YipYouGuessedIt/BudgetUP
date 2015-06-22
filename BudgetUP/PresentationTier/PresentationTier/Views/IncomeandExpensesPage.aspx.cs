using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class IncomeandExpensesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ActID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }
            List<Activity> proj = new List<Activity>();
            using (var dbContext = new dboEntities())
            {

                var query = from Objectives
                            in dbContext.Activities 
                            select Objectives;

                proj = query.ToList<Activity>();
                foreach (Activity p in proj)
                {

                    if (p.Id.ToString() == Session["ActID"].ToString())
                    {
                        heaserarea.InnerText = p.ActivityName.ToString();
                    }
                }
            }
            this.addDynamics();
        }

        protected void Eclicker(object sender, EventArgs e)
        {
            LinkButton m = (LinkButton)sender;
            char[] ma = ";;".ToCharArray();
            string[] container = m.ID.Split(ma);

                Response.Write("<script>alert('" + container[1] + "')</script>");
            if (container[2].ToString() == "contractor")
            {
                Session["contractorID"] = container[0];
                Response.Redirect("ViewServiceProvider.aspx");
            }
            else if (container[2].ToString() == "equipment")
            {
                Session["equipID"] = container[0];
                Response.Redirect("ViewEquipment.aspx");
            }
            else if (container[2].ToString() == "operational")
            {
                Session["operationalID"] = container[0];
                Response.Redirect("ViewOperationalActivity.aspx");
            }
            else if (container[2].ToString() == "travel")
            {
                Session["TravelID"] = container[0];
                Response.Redirect("ViewTravelActivity.aspx");
            }
            else if (container[2].ToString() == "staff")
            {
                Session["UPstaffID"] = container[0];
                Response.Redirect("ViewPersonalActivity.aspx");
            }
            else
            {

            }
            
        }

        protected void Iclicker(object sender, EventArgs e)
        {
            LinkButton m = (LinkButton)sender;
            char[] ma = "Income".ToCharArray();
            Session["IncID"] = m.ID.Split(ma)[0];
            Response.Redirect("ViewDonation.aspx");
        }

        protected void Bclicker(object sender, EventArgs e)
        {
            LinkButton m = (LinkButton)sender;
            char[] ma = "Burser".ToCharArray(); 
            Session["BursIDID"] = m.ID.Split(ma)[0];
            Response.Redirect("ViewBursary.aspx");
        }


        protected void addDynamics()
        {
                //Response.Write("<script>alert(' mdksnfc')</script>");
                List<Expens> px = new List<Expens>();
                using (var dbContext2 = new dboEntities())
                {
                    var query2 = from Objectives
                                 in dbContext2.Expenses
                                 select Objectives;
                    foreach (Expens v in query2)
                    {

                        if (v.ActivityId.ToString() == Session["ActID"].ToString())
                        {
                            //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
                            var query3 = from Objectives
                                         in dbContext2.Contractors
                                         select Objectives;
                            foreach (Contractor m in query3)
                            {
                                if (m.Expense_Id == v.Id)
                                {
                                    LinkButton add = new LinkButton();
                                    add.Text = m.ContractorName + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID =  m.Id.ToString() + ";;contractor";
                                    add.CssClass = "list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                }
                            }
                            //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
                            var query4 = from Objectives
                                         in dbContext2.Equipments
                                         select Objectives;
                            foreach (Equipment m in query4)
                            {
                                if (m.Expense_Id == v.Id)
                                {
                                    LinkButton add = new LinkButton();
                                    add.Text = m.EquipmentName + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID = m.Id.ToString() + ";;equipment";
                                    add.CssClass = "list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                }
                            }
                            //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
                            var query5 = from Objectives
                                         in dbContext2.Operationals
                                         select Objectives;
                            foreach (Operational m in query5)
                            {
                                if (m.Expense_Id == v.Id)
                                {
                                    LinkButton add = new LinkButton();
                                    add.Text = m.Operation_Type.Description + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID = m.Id.ToString() + ";;operational";
                                    add.CssClass = "list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                }
                            }
                            //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
                            var query6 = from Objectives
                                         in dbContext2.Travels
                                         select Objectives;
                            foreach (Travel m in query6)
                            {
                                if (m.Expense_Id == v.Id)
                                {
                                    LinkButton add = new LinkButton();
                                    add.Text = "Travel" + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID = m.Id.ToString() + ";;travel";
                                    add.CssClass = "list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                }
                            }
                            //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
                            var query7 = from Objectives
                                         in dbContext2.UPStaffMembers
                                         select Objectives;
                            foreach (UPStaffMember m in query7)
                            {
                                if (m.Expense_Id == v.Id)
                                {
                                    LinkButton add = new LinkButton();
                                    add.Text = "UP Staff member" + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID = m.Id.ToString() + ";;staff";
                                    add.CssClass = "list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                }
                            }
                        }
                    }

 
                using (var dbContext = new dboEntities())
                {
                    var query = from Objectives
                                in dbContext.Incomes
                                 select Objectives;


                    //px = query2;
                    foreach (Income v in query)
                    {

                        if (v.ProjectId.ToString() == Session["projectID"].ToString())
                        {
                            LinkButton add = new LinkButton();
                            add.Text = v.DonorName  + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                            add.ID = v.Id.ToString()+"Income";
                            add.CssClass = "list-group-item";
                            add.Click += new EventHandler(Iclicker);
                            IncomeList.Controls.Add(add);


                        }
                    }
                }
                using (var dbContext3 = new dboEntities())
                {
                    var query3 = from Objectives
                                in dbContext3.Bursaries
                                 select Objectives;


                    //px = query2;
                    foreach (Bursary v in query3)
                    {

                        if (v.ProjectId.ToString() == Session["projectID"].ToString())
                        {
                            LinkButton add = new LinkButton();
                            add.Text = v.BursaryType.Description + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                            add.ID = v.Id.ToString() +"Burser";
                            add.CssClass = "list-group-item";
                            add.Click += new EventHandler(Bclicker);
                            BusaryList.Controls.Add(add);


                        }
                    }
                }
            }
        }
        //
        //Bursary End
        //

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32( DropDownList2.SelectedValue) == 1)
            {
                Response.Redirect("Personelactivity.aspx");
            }
            else if(Convert.ToInt32( DropDownList2.SelectedValue) == 2)
            {
                Response.Redirect("ServiceProviderActivity.aspx");
            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 3)
            {
                Response.Redirect("OperationalActivity.aspx");
            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 4)
            {
                Response.Redirect("EquipmentActivity.aspx");

            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 5)
            {
                Response.Redirect("TravelActivity.aspx");
            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 6)
            {
                Response.Redirect("BursaryActivity.aspx");
            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 7)
            {
                Response.Redirect("DonationActivity.aspx");
            }
            else
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (searcher.Text == "")
            {
                foreach (LinkButton m in lister.Controls.OfType<LinkButton>())
                {

                    m.Visible = true;

                }
            }
            else
            {
                foreach (LinkButton m in  Expenselist.Controls)
                {
                    if (m.Text.Split('<')[0].ToLower().ToString().Contains(searcher.Text.ToLower().ToString()))
                    {
                        m.Visible = true;
                    }
                    else
                    {
                        m.Visible = false;
                    }
                }
                foreach (LinkButton m in BusaryList.Controls)
                {
                    if (m.Text.Split('<')[0].ToLower().ToString().Contains(searcher.Text.ToLower().ToString()))
                    {
                        m.Visible = true;
                    }
                    else
                    {
                        m.Visible = false;
                    }
                }
                foreach (LinkButton m in IncomeList.Controls)
                {
                    if (m.Text.Split('<')[0].ToLower().ToString().Contains(searcher.Text.ToLower().ToString()))
                    {
                        m.Visible = true;
                    }
                    else
                    {
                        m.Visible = false;
                    }
                }

            }
        }
    }
}
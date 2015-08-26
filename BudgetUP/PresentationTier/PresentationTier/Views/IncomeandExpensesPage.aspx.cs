using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;
using System.IO;

namespace PresentationTier.Views
{
    public partial class IncomeandExpensesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible = false;
            if (Session["ActID"] == null)
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
                        heaserarea.InnerText =p.ActivityName.ToString() + " details";
                        tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt <a href='ObjectivesPage.aspx'>Project Details and Objective List</a> &gt <a href='ActivitiesPage.aspx'>Objective Details and Activity List</a> &gt Activity Details";
                        DateTime s = p.StartDate;
                        DateTime en = p.EndDate;
                        Div2.InnerHtml = "<p><b>Activity name:</b>" + p.ActivityName + "<p/><p><b>Duration:</b>" + s.ToString("yyyy/MM/dd") + " - " + en.ToString("yyyy/MM/dd") + "<p/>";
                      
                    }
                }

                LinkButton DownloadReport = new LinkButton();
                DownloadReport.Text = "<span class='glyphicon glyphicon-download pull-right' hidden='hidden' aria-hidden='true''</span> Download Excel";
                DownloadReport.ID = "DownloadReport";
                DownloadReport.CssClass = "btn-success btn-sm pull-right";
                DownloadReport.Click += new EventHandler(DownloadReport_Click);
                tree.Controls.Add(DownloadReport);

                LinkButton EmailReport = new LinkButton();
                EmailReport.Text = "<span class='glyphicon glyphicon-envelope pull-right' hidden='hidden' aria-hidden='true''</span> DRIS Submit";
                EmailReport.ID = "EmailReport";
                EmailReport.CssClass = "btn-warning btn-sm pull-right";
                EmailReport.Click += new EventHandler(EmailReport_Click);
                tree.Controls.Add(EmailReport);
            }
            this.addDynamics();
                        }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Eclicker(object sender, EventArgs e)
        {
            try{
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
            else if (container[2].ToString() == "car")
            {
                Session["car"] = container[0];
                Response.Redirect("ViewCar.aspx");
            }
            else
            {

            }
                        }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
            
        }

        protected void Iclicker(object sender, EventArgs e)
        {
            try
            {
            LinkButton m = (LinkButton)sender;
            char[] ma = "Income".ToCharArray();
            Session["IncID"] = m.ID.Split(ma)[0];
            Response.Redirect("ViewDonation.aspx");
                        }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Bclicker(object sender, EventArgs e)
        {
            try
            { 
            LinkButton m = (LinkButton)sender;
            char[] ma = "Burser".ToCharArray(); 
            Session["BursIDID"] = m.ID.Split(ma)[0];
            Response.Redirect("ViewBursary.aspx");
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }


        protected void addDynamics()
        {
            try
            {
                //Response.Write("<script>alert(' mdksnfc')</script>");
                List<Expens> px = new List<Expens>();
                int total, burs = 0, don = 0, money = 0;
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
                                    add.Text = m.ContractorName + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID =  m.Id.ToString() + ";;contractor";
                                    add.CssClass = "list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                    money++;
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
                                    add.Text = m.EquipmentName + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID = m.Id.ToString() + ";;equipment";
                                    add.CssClass = "list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                    money++;
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
                                    add.Text = m.Operation_Type.Description + " operation<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID = m.Id.ToString() + ";;operational";
                                    add.CssClass = "list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                    money++;
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
                                    add.Text = m.TravellerName + " to " + m.Destination + " <span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID = m.Id.ToString() + ";;travel";
                                    add.CssClass = "over list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                    money++;
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
                                    add.Text = "UP Staff member("+ m.PostLevel.Description+ ")<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID = m.Id.ToString() + ";;staff";
                                    add.CssClass = "over list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    if (m.SubventionLevy == false)
                                    {
                                        IncomeList.Controls.Add(add);
                                        don++;
                                        
                                    }
                                    else
                                    {
                                        Expenselist.Controls.Add(add);
                                        money++;
                                    }
                                   
                                }
                            }
                            var query8 = from Objectives
                                         in dbContext2.Cars
                                         select Objectives;
                            foreach (Car m in query8)
                            {
                                if (m.ExpensId == v.Id)
                                {
                                    string type = "";
                                    if(m.TypeofRental ==1)
                                    {
                                        type = "UPFleet";
                                    }
                                    else if (m.TypeofRental ==2)
                                    {
                                        type = "External";
                                    }
                                    else if (m.TypeofRental == 3)
                                    {
                                        type = "Fuel claim";
                                    }
                                    else
                                    {
                                        type = "none";
                                    }

                                    LinkButton add = new LinkButton();
                                    add.Text = "Car("+ type + ")<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                                    add.ID = m.Id.ToString() + ";;car";
                                    add.CssClass = "over  list-group-item";
                                    add.Click += new EventHandler(Eclicker);
                                    Expenselist.Controls.Add(add);
                                    money++;
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
                            add.Text = v.DonorName + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                            add.ID = v.Id.ToString()+"Income";
                            add.CssClass = "over list-group-item";
                            add.Click += new EventHandler(Iclicker);
                            IncomeList.Controls.Add(add);
                            don++;

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
                            add.Text = v.BursaryType.Description + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                            add.ID = v.Id.ToString() +"Burser";
                            add.CssClass = "over list-group-item";
                            add.ToolTip = "Click to view details of bursary";
                            add.Click += new EventHandler(Bclicker);
                            BusaryList.Controls.Add(add);
                            burs++;

                        }
                    }
                    total = burs + money + don;
                    if (total >= 10)
                    {

                        ObjectiveSearch.Visible = true;
                        buttonadd.CssClass = "btnb btn btn-info btn-lg ";
                    }
                    else
                    {
                        ObjectiveSearch.Visible = false;
                        buttonadd.CssClass = "btna btn btn-info btn-lg ";
                        //ObjectiveList.InnerHtml += "<br/><br/><br/>";

                    }
                    if (money == 0)
                    {

                        el.Visible = false;
                        Div1.InnerHtml = "<p>This is your gateway to manage incomes and expenses of your selected activity. Click on the button below to add incomes or expenses or edit the activity.</p>";
                    }
                    else
                    {
                        Div1.InnerHtml = "<p>This is the gateway to manage incomes and expenses of your selected activity. Below is a list of all the incomes or expenses you created.Click on a incomes or expenses item to manage it or edit the activity.</p>";
                    }
                    if (don == 0)
                    {

                        il.Visible = false;
                        Div1.InnerHtml = "<p>This is your gateway to manage incomes and expenses of your selected activity. Click on the button below to add incomes or expenses or edit the activity.</p>";
                    }
                    else
                    {
                        Div1.InnerHtml = "<p>This is the gateway to manage incomes and expenses of your selected activity. Below is a list of all the incomes or expenses you created.Click on a incomes or expenses item to manage or edit the activity.</p>";
                    }
                    if (burs == 0)
                    {

                        bl.Visible = false;
                        Div1.InnerHtml = "<p>This is your gateway to manage incomes and expenses of your selected activity. Click on the button below to add incomes or expenses or edit the activity.</p>";
                    }
                    else
                    {
                        Div1.InnerHtml = "<p>This is the gateway to manage incomes and expenses of your selected activity. Below is a list of all the incomes or expenses you created.Click on a incomes or expenses item to manage or edit the activity.</p>";
                    }
                }
            }
                        }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }
        //
        //Bursary End
        //

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
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
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 8)
            {
                Response.Redirect("CarActivity.aspx");
            }
            else
            {

            }
                        }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Unnamed1_Click2(object sender, EventArgs e)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void DownloadReport_Click(object sender, EventArgs e)
        {
            try
            {

                ExcelExport temp = new ExcelExport();
                var ProjectFile = temp.PrintProject(Convert.ToInt32(Session["projectID"].ToString()));

                var memoryStream = new MemoryStream();
                ProjectFile.CopyTo(memoryStream);

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=" + temp.ProjectName + " " + DateTime.Now.ToString(@"yyyy-MM-dd") + ".xlsx");
                Response.BinaryWrite(memoryStream.ToArray());
                Response.End();
            }
            catch (Exception err)
            {

                // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void EmailReport_Click(object sender, EventArgs e)
        {
            try
            {

                ExcelExport temp = new ExcelExport();
                temp.EmailBudget(Convert.ToInt32(Session["projectID"].ToString()), Convert.ToInt32(this.Session["userID"].ToString()));
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal2').modal('show');", true);

            }
            catch (Exception err)
            {

                // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }
    }
}
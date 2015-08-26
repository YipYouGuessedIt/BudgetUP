using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ProjectsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible = false;
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            //Response.Write("<script>alert('" + this.Session["Admin"].ToString() + "');</script>");
                    
            //String cont = "Welcome " + this.Session["userTitle"] + " " + this.Session["userSname"];
            
            AllProjects.Visible = false;
            string cont = "Projects";
            wecomemsg.InnerHtml = "<h1>" + cont + "</h1>";
            this.addtoProjectLists();
            if(this.Session["Admin"].ToString() == "True".ToString())
            {
                adminnav.Visible = true;
                normalnav.Visible = false;
                this.adminadder();
            }
            else
            {
                adminnav.Visible = false;
                normalnav.Visible = true;
            }


            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);


            }
            
        }
        private void adminadder()
        {try
        { 

            AllProjects.Visible = true;
            List<Project> proj = new List<Project>();
            List<User> users = new List<User>();
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Users
                            select Projects;

                //Response.Write("<script>alert('" + query.Count() + "')</script>");
                users = query.ToList<User>();
                int counter = 0;
                foreach ( User u in users)
                {
                    var query2 = from Projects
                            in dbContext.Projects
                                select Projects;
                    proj = query2.ToList<Project>();
                    counter = 0;
                    
                    foreach ( Project p in proj)
                   {

                       if (u.Id == p.UserId && u.Id != (int)Session["userID"])
                    {
                        
                        LinkButton add = new LinkButton();
                        add.Text = p.Title + " ( " + u.Surname + ")" + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                        add.ID = p.Id.ToString();
                        add.CssClass = "list-group-item";
                        add.Click += new EventHandler(clicker);
                        add.ToolTip = "Click here to manage this projects budget";
                        counter++;
                        PlaceHolder1.Controls.Add(add);
                    }
                    }
                    if (counter < 10)
                    {
                        AllProjects.Visible = false;
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Method to link to next form when dynamic link button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void clicker(object sender,EventArgs e)
        {   
            try
            { 

            LinkButton m = (LinkButton)sender ;
            //Response.Write("<script>alert('" + m.ID + "')</script>");
            this.Session["projectID"] = m.ID;
            Response.Redirect("ObjectivesPage.aspx");
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }
        /// <summary>
        /// Populates all dynaimc objects such as projects and names
        /// </summary>
        protected void addtoProjectLists()
        {
            try
            { 
            List<Project> proj = new List<Project>();
            using (var dbContext = new dboEntities())
            {
                bool m = false;
                var query = from Projects
                            in dbContext.Projects
                            select Projects;
                
                //
                proj = query.ToList<Project>();
                int l = 0;
                foreach (Project p in proj)
                {
                    if (p.UserId == (int)Session["userID"])
                    {
                        m = true;
                        LinkButton add = new LinkButton();
                        add.Text = p.Title + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                        add.ID = p.Id.ToString();
                        add.CssClass = "list-group-item";
                        add.Click += new EventHandler(clicker);
                        add.ToolTip = "Click here to manage this projects budget";
                        projectList.Controls.Add(add);
                        l++;
                    }
                }

                int c = l;
                if(c >= 10)
                {
                    ProjectSearch.Visible = true;
                    buttonadd.CssClass = "btnb btn btn-info btn-lg ";
                }
                else
                {
                    ProjectSearch.Visible = false;
                    buttonadd.CssClass = "btna btn btn-info btn-lg ";
                }

                if(c==0)
                {
                    projectList.Visible = false;
                    buttonadd.CssClass = "btna btn btn-info btn-lg ";
                }
                
                Button1.Text = "<span class='glyphicon glyphicon-search pull-right' hidden='hidden' aria-hidden='true''</span>";
                //Button1.CssClass = "form form-control";
                if(m == false)
                {
                    Div1.InnerHtml = "<p>Welcome " + this.Session["userTitle"] + " " + this.Session["userSname"] + ",this is your gateway to manage projects budget. Click on the button below to add project budgets. Above are buttons that will allow you to download the report for the project you are in as well as submit the report to DRIS</p>";
                }
                else
                {
                    Div1.InnerHtml = "<p>Welcome " + this.Session["userTitle"] + " " + this.Session["userSname"] + ",this is your gateway to manage projects budgets. Below is a list of all the projects you created.Click on a project item to manage it. Above are buttons that will allow you to download the report for the project you are in as well as submit the report to DRIS</p>";
               
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

        //public static void moop()
        //{
        //    ProjectsPage m = new ProjectsPage();
        //    m.Unnamed2_TextChanged();
        //}

        protected void Unnamed2_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void searcher_PreRender(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            { 
            if (searcher.Text == "")
            {
                foreach (LinkButton m in projectList.Controls)
                {

                    m.Visible = true;

                }
                foreach (LinkButton m in PlaceHolder1.Controls)
                {

                    m.Visible = true;

                }
            }
            else
            {
                foreach (LinkButton m in projectList.Controls)
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
                foreach (LinkButton m in PlaceHolder1.Controls)
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

        protected void Unnamed1_Click1(object sender, EventArgs e)
        {

        }

    }
}
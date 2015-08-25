using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ActivitiesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                // errormsg.Visible = false;
            if (Session["ObjectiveID"] == null)
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
            List<Objective> proj = new List<Objective>();
            tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt <a href='ObjectivesPage.aspx'>Project Details and Objective List</a> &gt <a href='ActivitiesPage.aspx'>Objective Details and Activity List";

            using (var dbContext = new dboEntities())
            {

                var query = from Objectives
                            in dbContext.Objectives
                            select Objectives;

                proj = query.ToList<Objective>();
                foreach (Objective p in proj)
                {

                    if (p.Id.ToString() == Session["ObjectiveID"].ToString())
                    {
                        Div2.InnerHtml = "<b><p>Objective Name:</b> " + p.ObjectiveName.ToString()+"";
                        heaserarea.InnerText = p.ObjectiveName.ToString() + " Details and Activity List";
                        //tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt <a href='ObjectivesPage.aspx'>Project Details and Objective list</a> &gt Details and Activity List";
                    }
                }
            }

            this.addDynamics();
            }
            catch (Exception err)
            {

                // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
        }
         protected void clicker(object sender, EventArgs e)
        {
             try
             { 
            LinkButton m = (LinkButton)sender;
            //Response.Write("<script>alert('" + m.ID + "')</script>");
            Session["ActID"] = m.ID;
            Response.Redirect("IncomeandExpensesPage.aspx");
             }
             catch (Exception err)
             {

                 // errormsg.Visible = true;
                 messageforerror.InnerHtml = Class1.genericErr;
                 ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
             }
        }

        protected void addDynamics()
         {   
            try
            { 
            List<Activity> proj = new List<Activity>();
             using (var dbContext = new dboEntities())
             {
                 var query = from Objectives
                             in dbContext.Activities
                             select Objectives;


                 proj = query.ToList<Activity>();
             }
             int c = 0;
            foreach(Activity a in proj)
            {
                if (a.ObjectiveId.ToString() == Session["ObjectiveID"].ToString())
                {
                    LinkButton add = new LinkButton();
                    add.Text = a.ActivityName + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                    add.ID = a.Id.ToString();
                    add.CssClass = "list-group-item";
                    add.ToolTip = "Click to manage the activity";
                    add.Click += new EventHandler(this.clicker);
                    ActivityList.Controls.Add(add);
                    c++;

                }
            }
            if (c >= 10)
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
            if (c == 0)
            {

                n.Visible = false;
                Div1.InnerHtml = "<p>This is your gateway to manage activities of your selected objective. Click on the button below to add activities or edit the objective.</p>";
            }
            else
            {
                Div1.InnerHtml = "<p>This is the gateway to manage activities of your selected objective. Below is a list of all the activities you created.Click on a activity item to manage it or edit the objective.</p>";
            }
            
            }
            catch (Exception err)
            {

                // errormsg.Visible = true;
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
                foreach (LinkButton m in ActivityList.Controls)
                {

                    m.Visible = true;

                }
            }
            else
            {
                foreach (LinkButton m in ActivityList.Controls)
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

                // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                // errormsg.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                // errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
        }
        /// <summary>
        /// adds all dynamics
        /// </summary>
        
        


    }
}
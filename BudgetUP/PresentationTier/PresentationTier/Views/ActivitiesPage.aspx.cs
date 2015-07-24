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
                errormsg.Visible = false;
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
                        heaserarea.InnerText = p.ObjectiveName.ToString();
                        tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt <a href='ObjectivesPage.aspx'>" + p.Project.Title.ToString() + "</a> &gt" + p.ObjectiveName;
                    }
                }
            }

            this.addDynamics();
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
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

                 errormsg.Visible = true;
                 messageforerror.Text = Class1.genericErr;
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
            foreach(Activity a in proj)
            {
                if (a.ObjectiveId.ToString() == Session["ObjectiveID"].ToString())
                {
                    LinkButton add = new LinkButton();
                    add.Text = a.ActivityName + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                    add.ID = a.Id.ToString();
                    add.CssClass = "list-group-item";
                    add.Click += new EventHandler(this.clicker);
                    ActivityList.Controls.Add(add);


                }
            }
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
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

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
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
        /// <summary>
        /// adds all dynamics
        /// </summary>
        
        


    }
}
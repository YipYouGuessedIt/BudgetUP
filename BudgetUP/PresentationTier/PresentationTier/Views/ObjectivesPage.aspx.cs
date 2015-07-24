using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ObjectivesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
            errormsg.Visible = false;
            if (Session["projectID"] == null)
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
            List<Project> proj = new List<Project>();
            using (var dbContext = new dboEntities())
            {

                var query = from Projects
                            in dbContext.Projects
                            select Projects;

                proj = query.ToList<Project>();
                foreach (Project p in proj)
                {

                    if (p.Id.ToString() == Session["projectID"].ToString())
                    {
                        heaserarea.InnerText = p.Title.ToString();
                        tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt " + p.Title.ToString();
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

        /// <summary>
        /// Method to link to next form when dynamic link button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void clicker(object sender, EventArgs e)
        {
            try
            { 
            LinkButton m = (LinkButton)sender;
            //Response.Write("<script>alert('" + m.ID + "')</script>");
            Session["ObjectiveID"] = m.ID;
            Response.Redirect("ActivitiesPage.aspx");
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
        protected void addDynamics()
        {
            try
            { 
            List<Objective> proj = new List<Objective>();
            using (var dbContext = new dboEntities())
            {
                var query = from Objectives
                            in dbContext.Objectives
                            select Objectives;

                
                proj = query.ToList<Objective>();
                foreach (Objective p in proj)
                {
                    //Response.Write("<script>alert(' mdksnfc')</script>");

                    if (p.ProjectId.ToString() == Session["projectID"].ToString())
                    {
                       LinkButton add = new LinkButton();
                       add.Text = p.ObjectiveName + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                        add.ID = p.Id.ToString();
                        add.CssClass = "list-group-item";
                        add.Click += new EventHandler(clicker);

                        ObjectiveLister.Controls.Add(add);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            { 
            if (searcher.Text == "")
            {
                foreach (LinkButton m in ObjectiveLister.Controls)
                {

                    m.Visible = true;

                }
            }
            else
            {
                foreach (LinkButton m in ObjectiveLister.Controls)
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
    }
}
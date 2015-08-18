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
                        heaserarea.InnerText = p.Title.ToString() + " details and objective list";
                        DateTime s = p.StartDate.Value;
                        DateTime en = p.EndDate.Value;
                        Div2.InnerHtml = "<p><b>Overall objective:</b>" + p.Goal + "<p/><p><b>Dates:</b>" + s.ToString("yyyy/MM/dd") + " - " + en.ToString("yyyy/MM/dd") + "<p/>";
                        tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt " + p.Title.ToString();
                        LinkButton DownloadReport = new LinkButton();
                        DownloadReport.Text = "<span class='glyphicon glyphicon-download pull-right' hidden='hidden' aria-hidden='true''</span> Download Excel";
                        DownloadReport.ID = "DownloadReport";
                        DownloadReport.CssClass = "btn-success btn-sm pull-right";
                        DownloadReport.Click += new EventHandler(DownloadReport_Click);
                        tree.Controls.Add(DownloadReport);
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
                int c = 0;
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
                        c++;
                        ObjectiveLister.Controls.Add(add);
                    }
                }
                if (c >= 10)
                {

                    ObjectiveSearch.Visible = true;
                }
                else
                {
                    ObjectiveSearch.Visible = false;
                }
                if (c == 0)
                {

                    ObjectiveLister.Visible = false;
                    Div1.InnerHtml = "<p>This is your gateway to manage objectives of your selected project. Click on the button below to add objectives or edit the project.</p>";
                }
                else
                {
                    Div1.InnerHtml = "<p>This is your gateway to manage objectives of your selected project. Below is a list of all the objective you created.Click on a objective item to manage it or edit the project.</p>";
                }

                Button1.Text = "<span class='glyphicon glyphicon-search' hidden='hidden' aria-hidden='true''</span>";
                
                    
                
               

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
                Response.AddHeader("content-disposition", "attachment; filename=" + temp.ProjectName +" " + DateTime.Now.ToString(@"yyyy-MM-dd") + ".xlsx");
                Response.BinaryWrite(memoryStream.ToArray());
                Response.End();
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }
    }
}
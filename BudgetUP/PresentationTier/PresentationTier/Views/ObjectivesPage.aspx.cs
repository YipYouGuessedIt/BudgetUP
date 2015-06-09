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
                    }
                }
            }

            this.addDynamics();
        }

        /// <summary>
        /// Method to link to next form when dynamic link button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void clicker(object sender, EventArgs e)
        {
            LinkButton m = (LinkButton)sender;
            Response.Write("<script>alert('" + m.ID + "')</script>");
            Session["ObjectiveID"] = m.ID;
           // Response.Write("ObjectivesPage.aspx");
        }
        /// <summary>
        /// adds all dynamics
        /// </summary>
        protected void addDynamics()
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
                        add.Text = p.ObjectiveName + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                        add.ID = p.Id.ToString();
                        add.CssClass = "list-group-item";
                        add.Click += new EventHandler(clicker);

                        ObjectiveLister.Controls.Add(add);
                    }
                }

            }
        }
    }
}
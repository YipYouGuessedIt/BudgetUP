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

            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            
             String cont = "Welcome " + this.Session["userTitle"] + " " + this.Session["userSname"];
             wecomemsg.InnerHtml = "<h1>" + cont + "</h1>";
             this.addtoProjectLists();
             
            
            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            
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
            LinkButton m = (LinkButton)sender ;
            //Response.Write("<script>alert('" + m.ID + "')</script>");
            this.Session["projectID"] = m.ID;
            Response.Redirect("ObjectivesPage.aspx");
        }
        /// <summary>
        /// Populates all dynaimc objects such as projects and names
        /// </summary>
        protected void addtoProjectLists()
        {
            List<Project> proj = new List<Project>();
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Projects
                            select Projects;
                
                //Response.Write("<script>alert('" + query.Count() + "')</script>");
                proj = query.ToList<Project>();
                foreach (Project p in proj)
                {
                    if (p.UserId == (int)Session["userID"])
                    {
                        LinkButton add = new LinkButton();
                        add.Text = p.Title + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                        add.ID = p.Id.ToString();
                        add.CssClass = "list-group-item";
                        add.Click += new EventHandler(clicker);
                        projectList.Controls.Add(add);
                    }
                }

            }
        }

        //public static void moop()
        //{
        //    ProjectsPage m = new ProjectsPage();
        //    m.Unnamed2_TextChanged();
        //}

        protected void Unnamed2_TextChanged(object sender, EventArgs e)
        {
            
            if(searcher.Text == "")
            {
                foreach (LinkButton m in projectList.Controls)
                {

                        m.Visible = true;

                }
            }
            else
            
            {
                foreach(LinkButton m in projectList.Controls)
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

        protected void searcher_PreRender(object sender, EventArgs e)
        {

        }

    }
}
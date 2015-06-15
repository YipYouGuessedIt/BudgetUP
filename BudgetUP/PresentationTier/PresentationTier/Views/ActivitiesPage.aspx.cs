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
            if (Session["ObjectiveID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
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
                    }
                }
            }

            this.addDynamics();
        }
         protected void clicker(object sender, EventArgs e)
        {
            LinkButton m = (LinkButton)sender;
            //Response.Write("<script>alert('" + m.ID + "')</script>");
            Session["ActID"] = m.ID;
            Response.Redirect("IncomeandExpensesPage.aspx");
        }

        protected void addDynamics()
         {   List<Activity> proj = new List<Activity>();
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
                    add.Text = a.ActivityName + "<span class='glyphicon glyphicon-remove-sign pull-right' hidden='hidden' aria-hidden='true'></span>";
                    add.ID = a.Id.ToString();
                    add.CssClass = "list-group-item";
                    add.Click += new EventHandler(this.clicker);
                    ActivityList.Controls.Add(add);


                }
            }
         }

        protected void Button1_Click(object sender, EventArgs e)
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
        /// <summary>
        /// adds all dynamics
        /// </summary>
        
        


    }
}
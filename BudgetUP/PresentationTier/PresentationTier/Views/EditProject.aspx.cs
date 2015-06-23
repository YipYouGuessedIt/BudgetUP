using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["projectID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
            }

            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Projects
                            select Projects;


                foreach (Project p in query)
                {
                    if (p.Id.ToString() == Session["projectID"].ToString())
                    {
                        if (!IsPostBack)
                        {
                            
                            title.Text = p.Title;
                            goal.Text = p.Goal.ToString();
                            length.Text = p.Length.ToString();

                        }
                    }
                }

            }
        }

        protected void lengthType_Init(object sender, EventArgs e)
        {
            lengthType.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from DurationTypes
                            in dbContext.DurationTypes
                            select DurationTypes;

                foreach (DurationType p in query)
                {
                    // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    lengthType.Items.Add(m);
                }

            }
        }

        protected void AddProject_Click(object sender, EventArgs e)
        {
            ServiceContracts m = new ServiceContracts();
            Project p = new Project();
            p.Id = Convert.ToInt32(Session["projectID"].ToString());
            p.Goal = goal.Text;
            p.Length = Convert.ToInt32(length.Text);
            p.Title = title.Text;
            p.DurationTypeId = Convert.ToInt32(lengthType.SelectedValue);
            m.UpdateUserProject(p);

        }
         protected void AddProject_Click2(object sender, EventArgs e)
        {
            ServiceContracts m = new ServiceContracts();
            
            m.DeleteUserProject(Convert.ToInt32(Session["projectID"].ToString()));
        }
    }
}
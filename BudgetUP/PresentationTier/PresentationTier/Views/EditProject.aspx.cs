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
                setview.Visible = true;
            }
            else
            {
                adminnav.Visible = false;
                normalnav.Visible = true;
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
                            DateTime test = new DateTime();
                            var n = p.Objectives;
                            foreach(Objective bn in n)
                            {
                                var act = bn.Activities;
                                foreach(Activity mn in act)
                                {
                                    if(mn.EndDate > test)
                                    {
                                        test = mn.EndDate;
                                    }
                                }
                            }
                            DateTime m = p.StartDate.Value;
                            DateTime m2 = p.EndDate.Value;
                            if (m2 >= test)
                            {
                                title.Text = p.Title;
                                goal.Text = p.Goal.ToString();
                                string date = m.Year.ToString();
                                sdate.Text = m.ToString("yyyy-MM-dd");
                                edate.Text = m2.ToString("yyyy-MM-dd");
                            }
                            else
                            {

                            }

                        }
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

        protected void lengthType_Init(object sender, EventArgs e)
        {
            //lengthType.Items.Clear();
            //using (var dbContext = new dboEntities())
            //{
            //    var query = from DurationTypes
            //                in dbContext.DurationTypes
            //                select DurationTypes;

            //    foreach (DurationType p in query)
            //    {
            //        // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
            //        ListItem m = new ListItem();
            //        m.Value = p.Id.ToString();
            //        m.Text = p.Description.ToString();
            //        lengthType.Items.Add(m);
            //    }

            //}
        }

        protected void AddProject_Click(object sender, EventArgs e)
        {
            try
            { 
            DateTime start = Convert.ToDateTime(sdate.Text);
            DateTime end = Convert.ToDateTime(edate.Text);
            if (end > start)
            {
                ServiceContracts m = new ServiceContracts();
                Project p = new Project();
                p.Id = Convert.ToInt32(Session["projectID"].ToString());
                p.Goal = goal.Text;
                //p.Length = Convert.ToInt32(length.Text);
                p.Title = title.Text;
                int length;
                if (end.Day < start.Day)
                {
                    length = (end.Year - start.Year) * 12 + end.Month - start.Month - 1;
                }
                else
                {
                    length = (end.Year - start.Year) * 12 + end.Month - start.Month;
                    if (length == 0)
                    {
                        length = 1;
                    }
                }
                p.StartDate = Convert.ToDateTime(sdate.Text);
                p.EndDate = Convert.ToDateTime(edate.Text);
                // p.DurationTypeId = Convert.ToInt32(lengthType.SelectedValue);
                m.UpdateUserProject(p);
                Response.Redirect("ObjectivesPage.aspx");
            }
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }

        }
         protected void AddProject_Click2(object sender, EventArgs e)
        {
             try
             { 
            ServiceContracts m = new ServiceContracts();
            
            m.DeleteUserProject(Convert.ToInt32(Session["projectID"].ToString()));
            Session["projectID"] = null;
            Response.Redirect("ProjectsPage.aspx");
             }
             catch (Exception err)
             {

                 errormsg.Visible = true;
                 messageforerror.Text = Class1.genericErr;
             }
        }

         protected void Unnamed6_Click(object sender, EventArgs e)
         {
             try
             { 
             Response.Redirect("editSettings.aspx");
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
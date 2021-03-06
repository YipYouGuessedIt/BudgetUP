﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewDonation : System.Web.UI.Page
    {
        int notede = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible = false;
            if (Session["IncID"] == null)
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

            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Incomes
                            select Projects;


                foreach (Income p in query)
                {
                    if (p.Id.ToString() == Session["IncID"].ToString())
                    {
                        if (!IsPostBack)
                        {
                            name.Text = p.DonorName;
                            amount.Text = p.Amount.ToString();
                            note.Text = p.Note.UserNote;
                            
                        }
                        notede = p.Note_Id;
                    }
                }
                tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a> &gt <a href='ObjectivesPage.aspx'>Project Details and Objective List</a> &gt <a href='ActivitiesPage.aspx'>Objective Details and Activity List</a> &gt <a href='IncomeandExpensesPage.aspx'>Activity Details</a> &gt  Edit Donation";

            }
                        }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts m = new ServiceContracts();
            Income n = new Income();
            n.Id = Convert.ToInt32(Session["IncID"].ToString());
            n.ProjectId = Convert.ToInt32(Session["ProjectID"].ToString());
            n.Amount = Convert.ToInt32(amount.Text);
            n.DonorName = name.Text;
            n.Note_Id = notede;
            Note no = new Note();
            no.Id = notede;
            no.UserNote = note.Text.ToString();
            m.UpdateNotes(no);
            m.UpdateIncome(n);
            Response.Redirect("IncomeandExpensesPage.aspx");
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceContracts m = new ServiceContracts();
                m.DeleteIncome(Convert.ToInt32(this.Session["IncID"].ToString()));
                this.Session["IncID"] = null;
                Response.Redirect("IncomeandExpensesPage.aspx");
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PresentationTier.Views
{
    public partial class ServiceProviderActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errormsg.Visible = false;
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (this.Session["ActID"] == null)
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
                        }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();
            int noteID = sc.AddNotes(note.Text);
            int expID = sc.AddExpense(Convert.ToInt32(Session["ActID"].ToString()), Convert.ToDouble(amount.Text), noteID);
            sc.AddContractor(name.Text, expID);
            Response.Redirect("IncomeandExpensesPage.aspx");
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
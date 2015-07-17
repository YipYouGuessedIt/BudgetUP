﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class Personelactivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        private void AddPersonnel1(object sender, EventArgs e)
        {
            //ServiceContracts sc = new ServiceContracts();
            //int noteID = sc.AddNotes(note.Text);
            //int expID = sc.AddExpense(Convert.ToInt32(Session["ActID"].ToString()), Convert.ToDouble(), noteID);
            //sc.AddUPStaffMember(Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(numofdays.Text), Convert.ToBoolean(DropDownList1.SelectedIndex), expID);
            //Response.Redirect("IncomeandExpensesPage.aspx");
        }

        protected void DropDownList2_Init(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from PostLevels
                            in dbContext.PostLevels
                            select PostLevels;

                foreach (PostLevel p in query)
                {
                    // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    DropDownList2.Items.Add(m);
                }

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            using (var dbContext = new dboEntities())
            {
                var query = from PostLevel
                            in dbContext.PostLevels
                            select PostLevel;


                foreach (PostLevel p in query)
                {
                    if(p.Id == Convert.ToInt32(DropDownList2.SelectedValue))
                    {
                    ServiceContracts sc = new ServiceContracts();
                    int noteID = sc.AddNotes(note.Text);
                    int expID = sc.AddExpense(Convert.ToInt32(Session["ActID"].ToString()), Convert.ToDouble( p.AnnualSalary), noteID);
                    sc.AddUPStaffMember(Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(numofdays.Text), Convert.ToBoolean(Convert.ToInt32(DropDownList1.SelectedValue)), expID);
                    Response.Redirect("IncomeandExpensesPage.aspx");
                    }
                }
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;


namespace PresentationTier.Views
{
    public partial class ViewDomain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {

                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (this.Session["Admin"].ToString() == "False".ToString())
            {
                Response.Redirect("ProjectsPage.aspx");
            }
            if (this.Session["DomainID"] == null)
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
                var query = from OperationalTypes
                            in dbContext.EmailDomains
                            select OperationalTypes;


                //px = query2;
                foreach (EmailDomain v in query)
                {
                    LinkButton add = new LinkButton();
                    add.Text = v.Domain + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                    add.ID = v.Id.ToString() + "Income";
                    add.CssClass = "list-group-item";
                    add.Click += new EventHandler(Eclicker);
                    BursaryList.Controls.Add(add);
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            
        }
        protected void Eclicker(object sender, EventArgs e)
        {
            LinkButton m = (LinkButton)sender;
            char[] ma = "Income".ToCharArray();
            Session["DomainID"] = m.ID.Split(ma)[0];
            Response.Redirect("EditDomain.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
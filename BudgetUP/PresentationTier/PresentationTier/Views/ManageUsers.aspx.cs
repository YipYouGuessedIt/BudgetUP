﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ManageUsers : System.Web.UI.Page
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
            if(this.Session["Admin"].ToString() == "False".ToString())
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
                var query = from users
                            in dbContext.Users
                            select users;


                //px = query2;
                foreach (User v in query)
                {
                    LinkButton add = new LinkButton();
                    add.Text = v.Name + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                    add.ID = v.Id.ToString() + "Income";
                    add.CssClass = "list-group-item";
                    add.Click += new EventHandler(Eclicker);
                    BursaryList.Controls.Add(add);
                }
            }
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void Eclicker(object sender, EventArgs e)
        {
            try
            {
            LinkButton m = (LinkButton)sender;
            char[] ma = "Income".ToCharArray();
            Session["OtherUserID"] = m.ID.Split(ma)[0];
            Response.Redirect("OtherProfilePage.aspx");
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

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
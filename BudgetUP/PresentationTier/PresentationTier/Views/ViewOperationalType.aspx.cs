﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewOperationalType : System.Web.UI.Page
    {
        protected void Eclicker(object sender, EventArgs e)
        {
            try
            {
            LinkButton m = (LinkButton)sender;
            char[] ma = "Income".ToCharArray();
            Session["OperationalTypeID"] = m.ID.Split(ma)[0];
            Response.Redirect("EditOperationalTypes.aspx");
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
                if (searcher.Text == "")
                {
                    foreach (LinkButton m in BursaryList.Controls)
                    {

                        m.Visible = true;

                    }
                }
                else
                {
                    foreach (LinkButton m in BursaryList.Controls)
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
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a>  &gt <a href='Settings.aspx'>Settings</a>  &gt View Operation type";

            try
            {
                //errormsg.Visible = false;
                if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (this.Session["Admin"].ToString() == "False".ToString())
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
                            in dbContext.Operation_Type
                            select OperationalTypes;


                //px = query2;
                foreach (Operation_Type v in query)
                {
                    LinkButton add = new LinkButton();
                    add.Text = v.Description + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                    add.ID = v.Id.ToString() + "Income";
                    add.CssClass = "list-group-item";
                    add.Click += new EventHandler(Eclicker);
                    BursaryList.Controls.Add(add);
                }
            }
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

   
    }
}
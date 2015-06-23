﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewBursaryTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == "false")
            {
                Response.Redirect("Settings.aspx");
            }
            using (var dbContext = new dboEntities())
            {
                var query = from bursaryType
                            in dbContext.BursaryTypes
                            select bursaryType;


                //px = query2;
                foreach (BursaryType v in query)
                {
                    LinkButton add = new LinkButton();
                    add.Text = v.Description + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                    add.ID = v.Id.ToString() + "Income";
                    add.CssClass = "list-group-item";
                    add.Click += new EventHandler(Iclicker);
                    BursaryList.Controls.Add(add);                    
                }
            }
        }

        protected void Iclicker(object sender, EventArgs e)
        {
            LinkButton m = (LinkButton)sender;
            char[] ma = "Income".ToCharArray();
            Session["BursaryTypeID"] = m.ID.Split(ma)[0];
            Response.Redirect("EditBursaryTypes.aspx");
        }

        public void AddBursary(object sender, EventArgs e)
        {
            Response.Redirect("AddBursaryType.aspx");
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class EditOperationalTypes : System.Web.UI.Page
    {
        
        protected void addOperationType(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();

            Operation_Type bt = new Operation_Type();

            bt.Id = Convert.ToInt32(this.Session["OperationalTypeID"].ToString());
            bt.Description = OperationDescription.Text;

            sc.UpdateOperationalType(bt);

            Response.Redirect("Settings.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (Session["OperationalTypeID"] == null)
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
            if (this.Session["OperationalTypeID"] == null)
            {
                Response.Redirect("Settings.aspx");
            }
            else
            {
                using (var dbContext = new dboEntities())
                {
                    var query = from OperationalType
                                in dbContext.Operation_Type
                                select OperationalType;


                    foreach (Operation_Type p in query)
                    {
                        if (p.Id.ToString() == Session["OperationalTypeID"].ToString())
                        {
                            if (!IsPostBack)
                            {
                                OperationDescription.Text = p.Description.ToString();
                            }
                        }
                    }

                }
            }
        }

        protected void DeleteOperationalType(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteOperationalType(Convert.ToInt32(this.Session["OperationalTypeID"].ToString()));
            Response.Redirect("Settings.aspx");
        }
        
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class CarActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            int noteID = sc.AddNotes(note.Text);
            int actID = Convert.ToInt32(this.Session["ActID"].ToString());
            int expID = sc.AddExpense(actID, Convert.ToDouble( quantity.Text) , noteID);
            sc.AddCarExpense(Convert.ToBoolean(fleet.SelectedIndex), expID);
            
        }
    }
}
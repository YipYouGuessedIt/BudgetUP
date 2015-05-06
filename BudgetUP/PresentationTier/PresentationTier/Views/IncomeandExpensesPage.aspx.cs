using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public partial class IncomeandExpensesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32( DropDownList2.SelectedValue) == 1)
            {
                Response.Redirect("Personelactivity.aspx");
            }
            else if(Convert.ToInt32( DropDownList2.SelectedValue) == 2)
            {
                Response.Redirect("ServiceProviderActivity.aspx");
            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 3)
            {
                Response.Redirect("OperationalActivity.aspx");
            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 4)
            {
                Response.Redirect("EquipmentActivity.aspx");

            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 5)
            {
                Response.Redirect("TravelActivity.aspx");
            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 6)
            {
                Response.Redirect("BursaryActivity.aspx");
            }
            else if (Convert.ToInt32(DropDownList2.SelectedValue) == 7)
            {
                Response.Redirect("DonationActivity.aspx");
            }
            else
            {

            }
        }
    }
}
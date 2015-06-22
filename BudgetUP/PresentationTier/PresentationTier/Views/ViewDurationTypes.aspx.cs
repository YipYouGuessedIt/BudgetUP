using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ViewDurationTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var dbContext = new dboEntities())
            {
                var query = from DurationTypes
                            in dbContext.DurationTypes
                            select DurationTypes;


                //px = query2;
                foreach (DurationType v in query)
                {
                    LinkButton add = new LinkButton();
                    add.Text = v.Description + "<span class='glyphicon glyphicon-menu-right pull-right' hidden='hidden' aria-hidden='true'></span>";
                    add.ID = v.Id.ToString() + "Income";
                    add.CssClass = "list-group-item";
                    add.Click += new EventHandler(Iclicker);
                    BusaryList.Controls.Add(add);
                }
            }
        }

        protected void Iclicker(object sender, EventArgs e)
        {
            LinkButton m = (LinkButton)sender;
            char[] ma = "Income".ToCharArray();
            Session["DurationTypeID"] = m.ID.Split(ma)[0];
            Response.Redirect("EditDurationType.aspx");
        }
    }
}
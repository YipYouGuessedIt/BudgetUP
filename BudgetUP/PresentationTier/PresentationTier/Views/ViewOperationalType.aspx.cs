using System;
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
            LinkButton m = (LinkButton)sender;
            char[] ma = "Income".ToCharArray();
            Session["OperationalTypeID"] = m.ID.Split(ma)[0];
            Response.Redirect("EditOperationalType.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}
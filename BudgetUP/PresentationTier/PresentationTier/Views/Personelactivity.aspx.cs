using System;
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string m = ";;staff";
            string[] d = m.Split(";;".ToCharArray());

            Response.Write("<script>alert('" + d.Length + "')</script>");
        }
    }
}
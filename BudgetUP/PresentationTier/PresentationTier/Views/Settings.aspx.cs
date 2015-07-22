using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PresentationTier.Views;
using System.IO;

namespace PresentationTier.Styles
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ExcelExport temp = new ExcelExport();
            var ProjectFile = temp.PrintProject(1);

            var memoryStream = new MemoryStream();
            ProjectFile.CopyTo(memoryStream);

            Response.Clear();
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment; filename=" + /*temp.ProjectName +*/" " + DateTime.Now.ToString(@"yyyy-MM-dd") + ".xlsx");
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }
    }
}
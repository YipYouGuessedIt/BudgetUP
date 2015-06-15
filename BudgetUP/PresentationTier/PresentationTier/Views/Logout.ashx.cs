using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationTier.Views
{
    /// <summary>
    /// Summary description for Logout
    /// </summary>
    public class Logout : IHttpHandler ,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("hello");
            context.Session.Clear();
            context.Response.Redirect("ProjectsPage.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
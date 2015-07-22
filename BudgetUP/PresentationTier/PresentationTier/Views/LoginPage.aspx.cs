using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;
using System.ComponentModel;

namespace PresentationTier
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ProjectsPage.aspx");
           Boolean domaincorrect = checkEmailDomain();
            if(domaincorrect == true)
            {
                Boolean creds = checkCred();
                if(creds == true)
                {
                    Response.Redirect("ProjectsPage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Details are incorrect')</script>");
                    Response.Redirect("LoginPage.aspx");
                }
            }
            else
            {
                Pass.Text = "";
            }
        }
        /// <summary>
        /// This function takes the users email and checks that the domain is apart of the
        /// the available ones for login.
        /// </summary>
        /// <returns>true if it exists but false if it does not exist</returns>
        private Boolean checkEmailDomain()
        {
            string dom = UserEmail.Text.Split('@')[1];
            List<EmailDomain> cred = new List<EmailDomain>();
            using (var dbContext = new dboEntities())
            {
                var query = dbContext.EmailDomains.Where(b => b.Domain == dom).FirstOrDefault();
                if(query == null)
                {
                    Response.Write("<script>alert('Email Domain is incorrect')</script>");
                    return false;
                }
                return true;
                 
            }
        }

        private Boolean checkCred()
        {
            using (var dbContext = new dboEntities())
            {
                var query = dbContext.UserCredentials.Where(b => b.Email == UserEmail.Text && b.Password == Pass.Text).FirstOrDefault();
                if (query == null)
                {
                    
                    return false;
                }
                else
                {
                    this.Session["userID"] = query.Id;
                    this.Session["userTitle"] = query.User.Title.Description;

                    this.Session["userSname"] = query.User.Surname;
                    this.Session["Admin"] = query.User.Admin;
                    return true;
                }
                

            }
            
        }
    }
}
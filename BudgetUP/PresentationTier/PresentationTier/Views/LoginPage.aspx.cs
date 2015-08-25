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
            //errormsg.Visible = false;
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ProjectsPage.aspx");
            try
            {
                Boolean domaincorrect = checkEmailDomain();
                if (domaincorrect == true)
                {
                    Boolean creds = checkCred();
                    if (creds == true)
                    {
                        Response.Redirect("ProjectsPage.aspx");
                    }
                    else
                    {
                        //errormsg.Visible = true;
                        messageforerror.InnerText = "The credentials entered were incorrect";
                        ClientScript.RegisterStartupScript(GetType(),"", "  $('#myModal').modal('show');", true);

                    }
                }
                else
                {
                    Pass.Text = "";
                }
            }
            catch(Exception err)
            {
                
               // errormsg.Visible = true;
                messageforerror.InnerText = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);
            }
        }
        /// <summary>
        /// This function takes the users email and checks that the domain is apart of the
        /// the available ones for login.
        /// </summary>
        /// <returns>true if it exists but false if it does not exist</returns>
        private Boolean checkEmailDomain()
        {
            try
            { 
            string dom = UserEmail.Text.Split('@')[1];
            List<EmailDomain> cred = new List<EmailDomain>();
            using (var dbContext = new dboEntities())
            {
                var query = dbContext.EmailDomains.Where(b => b.Domain == dom).FirstOrDefault();
                if(query == null)
                {
                    //m.Attributes.
                    //errormsg.Visible = true;
                    messageforerror.InnerHtml = "The domain entered was incorrect";
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "  $('#myModal').modal('show');",true);
                    return false;
                }
                return true;
                 
            }
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                //messageforerror.Text = Class1.genericErr;
                return false;
            }
        }

        private Boolean checkCred()
        {
            try
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
                    this.Session["userID"] = query.User_Id;
                    this.Session["userTitle"] = query.User.Title.Description;

                    this.Session["userSname"] = query.User.Surname;
                    this.Session["Admin"] = query.User.Admin;
                    return true;
                }
                

            }
            }
            catch (Exception err)
            {
                messageforerror.InnerText = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "hwa", "  $('#myModal').modal('show');", true);
                //errormsg.Visible = true;
                //messageforerror.Text = Class1.genericErr;
                return false;
            }
            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
               // errormsg.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {
                messageforerror.InnerText = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "hwa", "  $('#myModal').modal('show');", true);
                //errormsg.Visible = true;
                //messageforerror.Text = Class1.genericErr;
            }
        }
    }
}
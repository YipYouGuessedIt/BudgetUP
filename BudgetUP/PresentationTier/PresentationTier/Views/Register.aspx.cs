using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["Admin"] == null)
            {
                adminnav.Visible = false;
                normalnav.Visible = false;
                regDiv.Visible = true;
            }
            else
            {
                if (this.Session["Admin"].ToString() == "True".ToString())
                {
                    adminnav.Visible = true;
                    normalnav.Visible = false;
                    regDiv.Visible = false;
                }
                else
                {
                    adminnav.Visible = false;
                    normalnav.Visible = true;
                    regDiv.Visible = false;
                }
            }
        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            if (Password.Text != PasswordConfirm.Text)
            {
                //display error message
                //return;
            }
            else
            {
                bool m = checkEmailDomain();
                if (m == true)
                {
                    int userID = sc.AddUser(Convert.ToInt32(title.SelectedValue), name.Text, surname.Text, Convert.ToInt32(roles.SelectedValue), Convert.ToInt32(faculty.SelectedValue));
                    //select user here and get ID

                    sc.AddUserCredential(email.Text, Password.Text, userID);
                    if (this.Session["Admin"] == null)
                    {
                        Response.Redirect("LoginPage.aspx");
                    }
                    else
                    {
                        Response.Redirect("Settings.aspx");
                    }
                    
                }
            }
        }

        private Boolean checkEmailDomain()
        {
            string dom = email.Text.Split('@')[1];
            List<EmailDomain> cred = new List<EmailDomain>();
            using (var dbContext = new dboEntities())
            {
                var query = dbContext.EmailDomains.Where(b => b.Domain == dom).FirstOrDefault();
                if (query == null)
                {
                    Response.Write("<script>alert('Email Domain is incorrect')</script>");
                    return false;
                }
                return true;

            }
        }

        protected void title_Init(object sender, EventArgs e)
        {
            title.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from titles
                            in dbContext.Titles
                            select titles;

                foreach (Title p in query)
                {
                    // Response.Write("<script>alert('" + p.Id.ToString() + "');</script>");
                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    title.Items.Add(m);
                }

            }
        }
    }
}
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
            try
            {
                errormsg.Visible = false;
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
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();
            if (Password.Text != PasswordConfirm.Text)
            {
                errormsg.Visible = true;
                messageforerror.Text = "The two passwords dont match";
            }
            else
            {
                bool m = checkEmailDomain();
                bool emailexists = checkEmailExists();
                if (m == true)
                {
                    if (emailexists == false)
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
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        private Boolean checkEmailDomain()
        {
            try
            {
                string dom = email.Text.Split('@')[1];
            List<EmailDomain> cred = new List<EmailDomain>();
            using (var dbContext = new dboEntities())
            {
                var query = dbContext.EmailDomains.Where(b => b.Domain == dom).FirstOrDefault();
                if (query == null)
                {
                    errormsg.Visible = true;
                    messageforerror.Text = "Email Domain is incorrect";
                    return false;
                }
                return true;

            }
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
                return false;
            }
        }

        private Boolean checkEmailExists()
        {
            try
            {
                string dom = email.Text;
                List<EmailDomain> cred = new List<EmailDomain>();
                using (var dbContext = new dboEntities())
                {
                    var query = dbContext.UserCredentials.Where(b => b.Email == dom).FirstOrDefault();
                    if (query == null)
                    {

                        return false;
                    }
                    errormsg.Visible = true;
                    messageforerror.Text = "Email already exists";
                    return true;

                }
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
                return false;
            }
        }

        protected void DropDownList3_Init(object sender, EventArgs e)
        {
            try
    {
            faculty.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Faculties
                            select Projects;

                foreach (Faculty p in query)
                {

                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.FacultyName.ToString();
                    faculty.Items.Add(m);
                }

            }
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void DropDownList4_Init(object sender, EventArgs e)
        {
            try
            {
            roles.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Roles
                            select Projects;

                foreach (Role p in query)
                {

                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    roles.Items.Add(m);
                }

            }
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void title_Init(object sender, EventArgs e)
        {
            try
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
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }

        protected void roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                errormsg.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                errormsg.Visible = true;
                messageforerror.Text = Class1.genericErr;
            }
        }
    }
}
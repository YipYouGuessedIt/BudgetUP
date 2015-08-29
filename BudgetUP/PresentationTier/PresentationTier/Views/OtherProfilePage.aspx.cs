using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class OtherProfilePage : System.Web.UI.Page
    {
        private int uc = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible = false;
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            if (Session["OtherUserID"] == null)
            {
                Response.Redirect("ProjectsPage.aspx");
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
            tree.InnerHtml = "<a href='ProjectsPage.aspx'>Projects</a>  &gt <a href='Settings.aspx'>Settings</a>  &gt Edit users";
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Users
                            select Projects;
                int num = Convert.ToInt32(Session["OtherUserID"].ToString());

                var query2 = dbContext.UserCredentials.Where(b => b.User_Id == num).FirstOrDefault();


                foreach (User p in query)
                {
                    if (p.Id.ToString() == Session["OtherUserID"].ToString())
                    {


                        if (!IsPostBack)
                        {
                            if (query2 != null)
                            {

                                DropDownList1.SelectedValue = Convert.ToInt32(p.Admin).ToString();
                                DropDownList2.SelectedValue = p.RoleId.ToString();
                                DropDownList3.SelectedValue = p.FacultyId.ToString();
                                DropDownList4.SelectedValue = p.Faculty.ToString();
                                name.Text = p.Name;
                                name0.Text = p.Surname;
                                email.Text = query2.Email;
                                password.Text = query2.Password;
                                passwordconfirm.Text = query2.Password;
                            }


                        }
                        uc = query2.Id;
                    }
                }

            }
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void DropDownList2_Init(object sender, EventArgs e)
        {
            try
            {
            DropDownList2.Items.Clear();
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
                    DropDownList2.Items.Add(m);
                }

            }
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void DropDownList3_Init(object sender, EventArgs e)
        {
            try
            {
            DropDownList3.Items.Clear();
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
                    DropDownList3.Items.Add(m);
                }

            }
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }

        protected void DropDownList4_Init(object sender, EventArgs e)
        {
            try
            {
            DropDownList4.Items.Clear();
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Titles
                            select Projects;

                foreach (Title p in query)
                {

                    ListItem m = new ListItem();
                    m.Value = p.Id.ToString();
                    m.Text = p.Description.ToString();
                    DropDownList4.Items.Add(m);
                }

            }
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }

        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            try
            {
            if (password.Text == passwordconfirm.Text)
            {
                bool mi = checkEmailDomain();
                if (mi == true)
                {
                    User u = new User();
                    u.Id = Convert.ToInt32(Session["OtherUserID"].ToString());
                    u.Name = name.Text;
                    u.Surname = name0.Text;
                    u.TitleId = Convert.ToInt32(DropDownList4.SelectedValue);
                    u.RoleId = Convert.ToInt32(DropDownList2.SelectedValue);
                    u.FacultyId = Convert.ToInt32(DropDownList3.SelectedValue);
                    u.Admin = Convert.ToBoolean(Convert.ToInt32(DropDownList1.SelectedValue));
                    ServiceContracts m = new ServiceContracts();
                    m.UpdateUser(u);
                    UserCredential c = new UserCredential();
                    c.User_Id = Convert.ToInt32(Session["OtherUserID"].ToString());
                    c.Email = email.Text;
                    c.Password = password.Text;
                    c.Id = uc;
                    m.UpdateUserCredentials(c);
                    Response.Redirect("Settings.aspx");
                }
                
            }
            else
            {
                //errormsg.Visible = true;
                messageforerror.InnerHtml = "The two passwords dont match";
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

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
                    //errormsg.Visible = true;
                    messageforerror.InnerHtml = "Email Domain is incorrect";
                    ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

                    return false;
                    
                }
                return true;

            }
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

                return false;
            }
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
            ServiceContracts sc = new ServiceContracts();
            sc.DeleteUser(Convert.ToInt32(Session["OtherUserID"].ToString()));
            Response.Redirect("Settings.aspx");
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }


        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                //errormsg.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception err)
            {

                //errormsg.Visible = true;
                messageforerror.InnerHtml = Class1.genericErr;
                ClientScript.RegisterStartupScript(GetType(), "modalShower", "  $('#myModal').modal('show');", true);

            }
        }
    }
}
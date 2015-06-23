using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;

namespace PresentationTier.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        private int uc = 0;
        protected void Page_Load(object sender, EventArgs e)

        {
            if (Session.Count == 0)
            {
                // Response.Write("<script>alert('Credentials is incorrect')</script>");
                Response.Redirect("LoginPage.aspx");
            }
            using (var dbContext = new dboEntities())
            {
                var query = from Projects
                            in dbContext.Users
                            select Projects;
                int num = Convert.ToInt32(Session["userID"].ToString());

                var query2 = dbContext.UserCredentials.Where(b => b.User_Id == num).FirstOrDefault();


                foreach (User p in query)
                {
                    if (p.Id.ToString() == Session["userID"].ToString())
                    {
                        
                            
                        if (!IsPostBack)
                        {
                            DropDownList2.SelectedValue = p.RoleId.ToString();
                            DropDownList3.SelectedValue = p.FacultyId.ToString();
                            DropDownList4.SelectedValue = p.Faculty.ToString();
                            name.Text = p.Name;
                            name0.Text = p.Surname;
                            email.Text = query2.Email;
                            password.Text = query2.Password;
                            

                        }
                        uc = query2.Id;
                    }
                }

            }
        }

        protected void DropDownList2_Init(object sender, EventArgs e)
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

        protected void DropDownList3_Init(object sender, EventArgs e)
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

        protected void DropDownList4_Init(object sender, EventArgs e)
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

        protected void Unnamed6_Click(object sender, EventArgs e)
        {

            User u = new User();
            u.Id = Convert.ToInt32(Session["userID"].ToString());
            u.Name = name.Text;
            u.Surname = name0.Text;
            u.TitleId = Convert.ToInt32(DropDownList4.SelectedValue);
            u.RoleId = Convert.ToInt32(DropDownList2.SelectedValue);
            u.FacultyId = Convert.ToInt32(DropDownList3.SelectedValue);
            if (Session["Admin"].ToString() == "True".ToString())
            {
                u.Admin = true;
            }
            else
            {
                u.Admin = false;
            }
            ServiceContracts m = new ServiceContracts();
            m.UpdateUser(u);
            UserCredential c = new UserCredential();
            c.User_Id = Convert.ToInt32(Session["userID"].ToString());
            c.Email = email.Text;
            c.Password = password.Text;
            c.Id = uc;
            m.UpdateUserCredentials(c);
        }
    }
}
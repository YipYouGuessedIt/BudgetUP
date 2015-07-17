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

        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            if(Password.Text != PasswordConfirm.Text)
            {
                //display error message
                return;
            }
            int userID = sc.AddUser(title.SelectedIndex, name.Text, surname.Text, roles.SelectedIndex, faculty.SelectedIndex);
            //select user here and get ID
            sc.AddUserCredential(email.Text, Password.Text, userID);
            Response.Redirect("Login.aspx");
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
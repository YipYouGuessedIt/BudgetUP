using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            sc.AddUser(title.SelectedIndex, name.Text, surname.Text, roles.SelectedIndex, faculty.SelectedIndex);
            //select user here and get ID
            sc.AddUserCredential(email.Text, Password.Text, 0/*the users ID*/);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;
using System.Security.Cryptography;
using System.Text;

namespace PresentationTier.Views
{
    public partial class ForgotPassword_Verification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            string veriPassword = veriCode.Text;
            string Email = UserEmail.Text;
            string temp;
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Email + DateTime.Now.Day);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 8; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                temp = sb.ToString();
            }

            using(var dbContext = new dboEntities())
            {
                var entry = dbContext.Verifications
                        .Where(ad => ad.Email == Email)
                        .FirstOrDefault();

                if (veriPassword == entry.VericicationCode)
                {
                    Session["userID"] = entry.UserID;

                    Response.Redirect("ObjectivesPage.aspx");
                }
            }
        }
    }
}
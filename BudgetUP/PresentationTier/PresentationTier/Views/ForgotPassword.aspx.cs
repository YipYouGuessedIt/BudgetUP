using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTier;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

namespace PresentationTier.Views
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            ServiceContracts sc = new ServiceContracts();
            string userEmail = UserEmail.Text;
            int userID;
            String temp ="";
            using(var dbContext = new dboEntities())
            {
                var checkEmail = dbContext.Verifications
                        .Where(ad => ad.Email == userEmail)
                        .FirstOrDefault();

                if(checkEmail == null || checkEmail.UserID == null)
                {
                    var entry = dbContext.UserCredentials
                        .Where(ad => ad.Email == userEmail)
                        .FirstOrDefault();

                    userID = entry.User_Id;

                    //createCode
                    using(MD5 md5 = MD5.Create())
                    {
                        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(userEmail + DateTime.Now.Day);
                        byte[] hash = md5.ComputeHash(inputBytes);
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < 8; i++)
                        {
                            sb.Append(hash[i].ToString("X2"));
                        }
                        temp = sb.ToString();
                    }


                    sc.AddVerification(userID, userEmail,temp, DateTime.Now);
                }
                else
                {
                    Verification veri = new Verification();

                    var entry = dbContext.UserCredentials
                        .Where(ad => ad.Email == userEmail)
                        .FirstOrDefault();

                    userID = entry.User_Id;

                    //createCode
                    using(MD5 md5 = MD5.Create())
                    {
                        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(userEmail + DateTime.Now.Day);
                        byte[] hash = md5.ComputeHash(inputBytes);
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < 8; i++)
                        {
                            sb.Append(hash[i].ToString("X2"));
                        }
                        temp = sb.ToString();
                    }

                    veri.UserID = entry.User_Id;
                    veri.Email = userEmail;
                    veri.DateIssues = DateTime.Now;
                    veri.VericicationCode = temp;

                    sc.UpdateVerifications(veri);
                }
                //Send email
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.To.Add(userEmail);
                //mailMessage.From = new MailAddress("COS332Pop3@webmail.co.za");
                //mailMessage.Subject = "Budget UP verification Code";
                //mailMessage.Body = "Good day \r\n\r\n";
                //mailMessage.Body = "Your verification code is: " + temp + ".\r\n\r\n";
                //mailMessage.Body = "This verification code will expire at mid-night of the " + DateTime.Now.Date.ToString(@"yyyy-MM-dd");
                //SmtpClient smtpClient = new SmtpClient("mail.Webmail.co.za", 110);
                //smtpClient.Credentials = new System.Net.NetworkCredential("COS332Pop3@webmail.co.za", "Blah1234");
                //smtpClient.Send(mailMessage);

                string body = "Good day \r\n\r\n";
                body += "Your verification code is: " + temp + ".\r\n\r\n";
                body += "This verification code will expire at mid-night of the " + DateTime.Now.Date.ToString(@"yyyy-MM-dd");
                

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("budgetup2@gmail.com", "Blah1234"),
                    Timeout = 30000,
                };

                MailMessage message = new MailMessage("budgetup2@gmail.com", "yipyouguessedit@gmail.com", "Budget UP verification Code", body);
                smtp.Send(message);
                //082 697 1523


                Response.Redirect("ForgotPassword_Verification.aspx");
            }
        }
    }
}
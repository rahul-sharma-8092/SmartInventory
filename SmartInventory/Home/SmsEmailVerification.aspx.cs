using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartInventory.Home
{
    public partial class SmsEmailVerification : CommonFunc.PageBase
    {
        AuthDetails data = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["LoggedInUser"] != null)
                {
                    data = (AuthDetails)Session["LoggedInUser"];
                    SendOTP(data);
                }
                else
                {
                    Response.Redirect("~/" + StoreUserName + PageURL.Login);
                }
            }
        }

        protected void BtnVerfifyOTP_Click(object sender, EventArgs e)
        {

        }

        protected void BtnResendOTP_Click(object sender, EventArgs e)
        {
            data = (AuthDetails)Session["LoggedInUser"];
            if (data != null)
            {
                SendOTP(data);
            }
        }

        private void SendOTP(AuthDetails auth)
        {
            bool IsEmailSent = false, IsOTPStore = false;
            if (auth != null && !string.IsNullOrEmpty(auth.Email))
            {
                string OTP = new Random().Next(100000, 999999).ToString();
                IsOTPStore = new BAL.AccountMgt().AddStoreUserOTP(auth.StoreUserID, OTP, StoreUserName);

                if (IsOTPStore)
                {
                    EmailMsg email = new EmailMsg();
                    email.To = auth.Email;
                    email.Subject = "Smart Inventory - Email Verification";
                    email.IsHtml = true;

                    string templatePath = HttpContext.Current.Server.MapPath("~/Template/Email/EmailOTP.html");
                    string htmlTemplate = System.IO.File.ReadAllText(templatePath);

                    email.Body = htmlTemplate.Replace("{{UserName}}", auth.FullName).Replace("{{OTPCode}}", OTP);

                    IsEmailSent = Common.EmailService.SendEmail(email);

                    if (IsEmailSent)
                    {
                        new BAL.AccountMgt().AddEmailHistoryWithOTP(email, auth.StoreUserID, OTP, StoreUserName);
                        // Show Notification - Otp send successfully
                    }
                }
                else
                {
                    // Show Notification - Otp not send, something went wrong
                }
            }
            else
            {
                Response.Redirect("~/" + StoreUserName + PageURL.Login);
            }
        }
    }
}
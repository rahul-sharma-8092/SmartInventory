using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartInventory.Home
{
    public partial class SmsEmailVerification : CommonFunc.PageBase
    {
        AuthDetails data = null;
        string IpAddress = string.Empty;

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
            if (string.IsNullOrEmpty(otp1.Text) || string.IsNullOrEmpty(otp2.Text) || string.IsNullOrEmpty(otp3.Text) || string.IsNullOrEmpty(otp4.Text) || string.IsNullOrEmpty(otp5.Text) || string.IsNullOrEmpty(otp6.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.OTPInvalid}', 'error');", true);
                return;
            }
            else
            {
                data = (AuthDetails)Session["LoggedInUser"];
                string otp = otp1.Text + otp2.Text + otp3.Text + otp4.Text + otp5.Text + otp6.Text;
                
                if (data != null && !string.IsNullOrEmpty(data.Email))
                {
                    int result = BAL.AccountMgt.VerifyOTP(data.StoreUserID, data.Email, otp, StoreUserName);
                    if (result == 0)
                    {
                        // OTP Expired
                        data.IsOTPVerified = false;

                        BAL.AccountMgt.TrackLoginHistory(StoreUserName, data.Email, IpAddress, true, 0);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.OTPExpired}', 'error');", true);
                    }
                    else if (result == 1)
                    {
                        //OTP Verified - Proceed to Defaul.aspx[Dashboard]
                        data.IsOTPVerified = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.OTPVerified}', 'success');", true);

                        Session["LoggedInUser"] = null;
                        Session["LoggedInUser"] = data;

                        Response.Redirect("~/" + StoreUserName + PageURL.Default);
                    }
                    else
                    {
                        // Invalid OTP
                        data.IsOTPVerified = false;

                        BAL.AccountMgt.TrackLoginHistory(StoreUserName, data.Email, IpAddress, true, 0);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.OTPInvalid}', 'error');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.SomethingWentWrong}', 'error');", true);
                }
            }
        }

        protected void BtnResendOTP_Click(object sender, EventArgs e)
        {
            data = (AuthDetails)Session["LoggedInUser"];
            if (data != null)
            {
                SendOTP(data);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.SomethingWentWrong}', 'error');", true);
                Response.Redirect("~/" + StoreUserName + PageURL.Login);
            }
        }

        private void SendOTP(AuthDetails auth)
        {
            bool IsEmailSent = false, IsOTPStore = false;
            if (auth != null && !string.IsNullOrEmpty(auth.Email))
            {
                string OTP = new Random().Next(100000, 999999).ToString();
                IsOTPStore = BAL.AccountMgt.AddStoreUserOTP(auth.StoreUserID, OTP, StoreUserName);

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
                        BAL.AccountMgt.AddEmailHistoryWithOTP(email, auth.StoreUserID, OTP, StoreUserName);
                        // Show Notification - Otp send successfully
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.OTPSent}', 'success');", true);
                    }
                }
                else
                {
                    // Show Notification - Otp not send, something went wrong
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.InvalidLogin}', 'error');", true);
                }
            }
            else
            {
                Response.Redirect("~/" + StoreUserName + PageURL.Login);
            }
        }
    }
}
using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartInventory.Home
{
    public partial class ForgotPassword : CommonFunc.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim().ToLower();
            
            Entity.ForgotPassword obj = BAL.AccountMgt.GetPassResetLink(email, IpAddress, StoreUserName);

            if (obj != null && obj.ReturnCode == 1)
            {
                double Time = 30;
                if (!obj.IsGuidExpired && obj.GuidTimeStamp.AddMinutes(Time) > DateTime.Now)
                {

                    obj.ForgotURL = $"{Request.Url.Scheme}://{Request.Url.Authority}/{StoreUserName}/Home/SetPassword.aspx?token={obj.Guid}";

                    EmailMsg emailObj = new EmailMsg();
                    emailObj.To = obj.Email;
                    emailObj.Subject = "Smart Inventory - Reset Password Link.";
                    emailObj.IsHtml = true;

                    string templatePath = HttpContext.Current.Server.MapPath("~/Template/Email/ResetPassword.html");
                    string htmlTemplate = System.IO.File.ReadAllText(templatePath);

                    emailObj.Body = htmlTemplate
                    .Replace("{{FullName}}", obj.FullName)
                    .Replace("{{ForgotURL}}", obj.ForgotURL)
                    .Replace("{{Time}}", Time.ToString());

                    bool isEmailSent = Common.EmailService.SendEmail(emailObj);
                    if (isEmailSent)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.ForgotPasswordLink}', 'success');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.SomethingWentWrong}', 'error');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.SomethingWentWrong}', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.InvalidEmail}', 'error');", true);
            }
        }
    }
}
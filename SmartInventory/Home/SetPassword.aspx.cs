using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartInventory.Home
{
    public partial class SetPassword : CommonFunc.PageBase
    {
        string token = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["token"] != null)
            {
                token = Request.QueryString["token"].ToString().Trim();
            }
            if (!Page.IsPostBack)
            {
                SetValidation();
            }
            ValidateLinkToken();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string password = txtPassword.Text.Trim();
                string cnfPassword = txtConfirmPassword.Text.Trim();

                if (password != cnfPassword)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Common.Message.PassandCnfPassNotSame}', 'error', false);", true);
                    return;
                }

                Entity.SetPassword setPassword = new BAL.AccountMgt().ValidateResetPassToken(token, StoreUserName);
                setPassword.Password = Common.Security.BCryptEncryption(password);
                setPassword.ConfirmPassword = cnfPassword;

                if (setPassword != null && setPassword.ReturnCode == 1 && !setPassword.IsGuidExpired && !string.IsNullOrEmpty(setPassword.Email))
                {
                    bool result = new BAL.AccountMgt().SetPassword(setPassword, StoreUserName);

                    if (result)
                    {
                        Session["PasswordChanged"] = Common.Message.PasswordChanged;

                        EmailMsg emailObj = new EmailMsg();
                        emailObj.To = setPassword.Email;
                        emailObj.Subject = "Smart Inventory - Password Changed.";
                        emailObj.IsHtml = true;

                        string templatePath = HttpContext.Current.Server.MapPath("~/Template/Email/PasswordChanged.html");
                        string htmlTemplate = System.IO.File.ReadAllText(templatePath);

                        emailObj.Body = htmlTemplate.Replace("{{FullName}}", setPassword.FullName);

                        Common.EmailService.SendEmail(emailObj);

                        Response.Redirect("~/" + StoreUserName + PageURL.Login);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Common.Message.PasswordChangedFailed}', 'success', false);", true);
                    }
                }
            }
        }

        private void SetValidation()
        {
            reqPassword.ErrorMessage = reqConfirmPassword.ErrorMessage = Common.Message.RequiredField;
            regexPassword.ErrorMessage = Common.Message.InvalidInput;

            regexPassword.ValidationExpression = Common.Regexes.Password;
        }

        private void ValidateLinkToken()
        {
            Entity.SetPassword setPassword = new BAL.AccountMgt().ValidateResetPassToken(token, StoreUserName);

            if (setPassword != null && setPassword.ReturnCode == 1 && !setPassword.IsGuidExpired && !string.IsNullOrEmpty(setPassword.Email))
            {
                errorMessage.Visible = false;
                formDiv.Visible = true;
            }
            else
            {
                errorMessage.InnerText = Common.Message.InvalidVerificationLink;
                errorMessage.Visible = true;
                formDiv.Visible = false;
            }
        }
    }
}
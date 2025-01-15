using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartInventory.Home
{
    public partial class Login : CommonFunc.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PasswordChanged"] != null)
            {
                Session["PasswordChanged"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Common.Message.PasswordChanged}', 'success');", true);
            }

            StoreDetails = BAL.AccountMgt.GetStoreDetails(StoreUserName);
            if (StoreDetails != null && StoreDetails.Status == 1)
            {
                if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/" + StoreUserName + PageURL.Dashboard);
                }
                else
                {
                    FormsAuthentication.SignOut();
                }
            }
            else
            {
                //Store Not Active
                FormsAuthentication.SignOut();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.StoreNotActive}', 'error');", true);
            }

            if (!Page.IsPostBack && Request.QueryString["StoreNameChange"] != null)
            {
                string message = Convert.ToString(HttpUtility.UrlDecode(Request.QueryString["StoreNameChange"] ?? ""));
                if (message == "1")
                {
                    Session["StoreNameChange"] = message;
                }
                Response.Redirect("~/" + StoreUserName + PageURL.Login);
            }

            if (!Page.IsPostBack && Session["StoreNameChange"] != null)
            {
                Session["StoreNameChange"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "StoreNameChange", $"showNotification('{Message.StoreNameChange}', 'error');", true);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string IpAddress = Request.ServerVariables["REMOTE_ADDR"];
                if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    IpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0].Trim();
                }

                AuthDetails obj = BAL.AccountMgt.GetUserAuthDetails(txtEmail.Text, StoreUserName);
                if (obj != null && !string.IsNullOrEmpty(obj.Email))
                {
                    obj.IsAuthenticated = Common.Security.BCryptVerify(txtPassword.Text.Trim(), obj.Password);

                    if (obj.IsAuthenticated && obj.Status != 1)
                    {
                        BAL.AccountMgt.TrackLoginHistory(StoreUserName, obj.Email, IpAddress, true, obj.StoreUserID);
                        //Show Notification - Account Not Active
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.AccountLocked}', 'error');", true);
                    }
                    else if (obj.IsAuthenticated && obj.IsTempBlocked)
                    {
                        BAL.AccountMgt.TrackLoginHistory(StoreUserName, obj.Email, IpAddress, true, obj.StoreUserID);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.AccountTempBlocked}', 'error');", true);
                        //Show Notification - Account Temporarily Blocked. Try again after 10 min.
                    }
                    else if (obj.IsAuthenticated && obj.Status == 1)
                    {
                        // Everything is fine Proceed to Dashboard
                        obj.Password = "";
                        Session["LoggedInUser"] = obj;

                        if (obj.Is2FAEnabled)
                        {
                            Response.Redirect("~/" + StoreUserName + PageURL.Verification2FA);
                        }
                        else if (obj.IsOTPEnabled)
                        {
                            Response.Redirect("~/" + StoreUserName + PageURL.SmsEmailVerification);
                        }

                        Response.Redirect("~/" + StoreUserName + PageURL.Default);
                    }
                    else
                    {
                        //Show Notification - Invalid Credentials

                        BAL.AccountMgt.TrackLoginHistory(StoreUserName, obj.Email, IpAddress, true, obj.StoreUserID);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.InvalidLogin}', 'error');", true);
                    }
                }
                else
                {
                    //Show Notification - Invalid Credentials
                    BAL.AccountMgt.TrackLoginHistory(StoreUserName, txtEmail.Text.Trim(), IpAddress, true, 0);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.InvalidLogin}', 'error');", true);
                }
            }
        }
    }
}
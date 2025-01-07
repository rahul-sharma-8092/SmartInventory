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
            StoreDetails = new BAL.AccountMgt().GetStoreDetails(StoreUserName);
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
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AuthDetails obj = new BAL.AccountMgt().GetUserAuthDetails(txtEmail.Text, StoreUserName);
                if (obj != null && !string.IsNullOrEmpty(obj.Email))
                {
                    obj.IsAuthenticated = Common.Security.BCryptVerify(txtPassword.Text.Trim(), obj.Password);

                    if (obj.IsAuthenticated && obj.Status != 1)
                    {
                        //Show Notification - Account Not Active
                    }
                    else if (obj.IsAuthenticated && obj.IsTempBlocked)
                    {
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
                    }
                }
                else
                {
                    //Show Notification - Invalid Credentials
                }
            }
        }
    }
}
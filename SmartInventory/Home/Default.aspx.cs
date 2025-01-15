using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartInventory.Home
{
    public partial class Default : CommonFunc.PageBase
    {
        AuthDetails data = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUser"] != null)
            {
                data = (AuthDetails)Session["LoggedInUser"];
                Session["LoggedInUser"] = null;
            }

            if (HttpContext.Current.User == null || !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // User verified with OTP
                if (data != null && !string.IsNullOrEmpty(data.Email) && data.IsOTPEnabled && data.IsOTPVerified)
                {
                    CreateUserTicket(data);
                }
                else if (data != null && !string.IsNullOrEmpty(data.Email) && data.Is2FAEnabled && data.Is2FAVerified) // User verified with TOTP
                {
                    CreateUserTicket(data);
                }
                else if (data != null && !string.IsNullOrEmpty(data.Email) && !data.IsOTPEnabled) // User OTP Verification not enabled
                {
                    CreateUserTicket(data);
                }
                else // User Not Authenticated
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/" + StoreUserName + PageURL.Login);
                }
            }
        }

        private void CreateUserTicket(AuthDetails auth)
        {
            if (auth != null && !string.IsNullOrEmpty(auth.Email))
            {
                string userData = auth.StoreUserID.ToString() + "|" + // 0 - StoreUserID
                                  auth.FullName + "|" + // 1 - UserName
                                  auth.Email + "|" + // 2 - Email
                                  auth.GroupId + "|" + // 3 - GroupId
                                  StoreUserName + "|"; // 4 - StoreUserName

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, auth.FullName, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData);

                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                {
                    Expires = DateTime.Now.AddMinutes(30),
                    HttpOnly = true
                };

                BAL.AccountMgt.TrackLoginHistory(StoreUserName, auth.Email, IpAddress, false, auth.StoreUserID);

                Response.Cookies.Add(authCookie);
                Response.Redirect("~/" + StoreUserName + PageURL.Dashboard);
            }
            else
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/" + StoreUserName + PageURL.Login);
            }
        }
    }
}
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
                string userData = auth.StoreUserID.ToString() + "|" + // StoreUserID
                                  auth.FullName + "|" + // UserName
                                  auth.Email + "|" + // Email
                                  auth.GroupId + "|";  // GroupId

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, auth.FullName, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData);

                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                {
                    Expires = DateTime.Now.AddMinutes(30),
                    HttpOnly = true
                };

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
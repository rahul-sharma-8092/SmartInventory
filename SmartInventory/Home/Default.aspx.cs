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
        protected void Page_Load(object sender, EventArgs e)
        {
            string data = string.Empty;

            if (Session["LoggedInUser"] != null)
            {
                data = Session["LoggedInUser"].ToString().Trim();
                Session["LoggedInUser"] = null;
            }

            if (HttpContext.Current.User == null || !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(data))
                {
                    string userId = data.Split('|')[0];
                    string email = data.Split('|')[1];
                    CreateUserTicket(email, Convert.ToInt32(userId));
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/" + StoreUserName + PageURL.Login);
                }
            }
        }

        private void CreateUserTicket(string email, int userId, bool IsRememberMe = false)
        {
            Authentication obj = new BAL.AccountMgt().GetUserFullDetails(email, userId);
            if (obj != null && !string.IsNullOrEmpty(obj.Email))
            {
                string userName = obj.FirstName + " " + obj.LastName;
                string userData = obj.UserID.ToString() + "|" + //UserID
                                  userName + "|" + //UserName
                                  obj.Email + "|" + //Email
                                  obj.RoleId + "|" + //RoleID
                                  obj.Role; //RoleName

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(30), IsRememberMe, userData);

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
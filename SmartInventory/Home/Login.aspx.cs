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
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/" + StoreUserName + PageURL.Dashboard);
            }
            else
            {
                FormsAuthentication.SignOut();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AuthDetails obj = new BAL.AccountMgt().GetUserAuthDetails(txtEmail.Text);
                if (obj != null && !string.IsNullOrEmpty(obj.Email))
                {
                    obj.IsAuthenticated = Common.Security.BCryptVerify(txtPassword.Text.Trim(), obj.Password);

                    if (obj.IsAuthenticated)
                    {
                        string data = obj.UserID.ToString() + "|" + obj.Email;
                        Session["LoggedInUser"] = data;

                        Response.Redirect("~/" + StoreUserName + PageURL.Default);
                    }
                    else
                    {
                        //Show Notification - Invalid Credentials
                    }
                }
            }
        }
    }
}
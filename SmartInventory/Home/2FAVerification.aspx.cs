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
    public partial class _2FAVerification : CommonFunc.PageBase
    {
        AuthDetails data = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUser"] != null)
            {
                data = (AuthDetails)Session["LoggedInUser"];
                if (data.Is2FAEnabled && data.Is2FAVerified)
                {
                    Response.Redirect("~/" + StoreUserName + PageURL.Default);
                }
            }
            else
            {
                Response.Redirect("~/" + StoreUserName + PageURL.Login);
            }
        }

        protected void BtnVerify_Click(object sender, EventArgs e)
        {
            string secretKey = BAL.AccountMgt.GetUserTotpSecretKey(data.StoreUserID, StoreUserName);
            string code = txtCode.Text.Trim();

            if (string.IsNullOrEmpty(secretKey))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.NotSetup2FA}', 'error');", true);
                
                return;
                // Please setup 2FA first
            }
            bool IsValid = Common.Security.ValidateTotp(secretKey, code);

            if (IsValid)
            {
                data.Is2FAVerified = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.OTPVerified}', 'success');", true);

                Session["LoggedInUser"] = null;
                Session["LoggedInUser"] = data;

                Response.Redirect("~/" + StoreUserName + PageURL.Default);
            }
            else
            {
                data.IsOTPVerified = false;
                BAL.AccountMgt.TrackLoginHistory(StoreUserName, data.Email, IpAddress, true, data.StoreUserID);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Message.OTPInvalid}', 'error');", true);
            }
        }
    }
}
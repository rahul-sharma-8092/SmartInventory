using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

namespace SmartInventory.Home
{
    public partial class Setup2FA : CommonFunc.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayQrCode();
            }
        }

        private void DisplayQrCode()
        {
            string[] user = GetUserData();
            if (user.Length > 0)
            {
                string secretKey = Common.Security.GenerateTotpSecretKey();
                string qrCodeUri = Common.Security.GenerateTotpQrCodeUri(secretKey, user[2]);
                imgQrCode.ImageUrl = "data:image/png;base64," + qrCodeUri;

                Session["TotpSecret"] = secretKey;
            }
        }

        protected void BtnVerify_Click(object sender, EventArgs e)
        {
            string secretKey = (Session["TotpSecret"] ?? "").ToString().Trim();
            
            string[] user = GetUserData();

            if (!string.IsNullOrEmpty(secretKey) && !string.IsNullOrEmpty(user[0]) && !string.IsNullOrEmpty(user[2]))
            {
                bool IsValid = Common.Security.ValidateTotp(secretKey, txtVerificationCode.Text.Trim());
                if (IsValid)
                {
                    TotpUserData objTotp = new TotpUserData();
                    objTotp.StoreUserId = Convert.ToInt32(user[0]);
                    objTotp.Email = user[2].Trim();
                    objTotp.SecretKey = secretKey;

                    int result = new BAL.AccountMgt().AddStoreUserTOTP(objTotp, StoreUserName);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Common.Message.Added2FA}', 'success');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Common.Message.InvalidCode}', 'error', false);", true);
                }
            }
        }
    }
}
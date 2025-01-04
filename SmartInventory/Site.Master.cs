using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartInventory
{
    public partial class SiteMaster : MasterPage
    {
        public string StoreUserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            StoreUserName = HttpContext.Current.Items["StoreUserName"] as string;

            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                
            }
            else
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/" + StoreUserName + PageURL.Login);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/" + StoreUserName + PageURL.Login);
        }
    }
}
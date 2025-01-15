using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartInventory.Home.CommonFunc
{
    public class PageBase : System.Web.UI.Page
    {
        public string StoreUserName = string.Empty;
        public string IpAddress = string.Empty;
        public int IsAccess = 0;
        public StoreDetails StoreDetails = null;
        
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (RouteData.Values["StoreUserName"] != null)
            {
                StoreUserName = RouteData.Values["StoreUserName"].ToString();
            }

            IpAddress = Request.ServerVariables["REMOTE_ADDR"];
            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                IpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0].Trim();
            }
        }

        internal string[] GetUserData()
        {
            string[] userData = new String[10];
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // StoreUserId|UserName|Email|GroupId
                // 1001|Tony Stark|tonystark@armyspy.com|1|
                userData = ((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData.Split('|');
            }
            return userData;
        }
    }
}
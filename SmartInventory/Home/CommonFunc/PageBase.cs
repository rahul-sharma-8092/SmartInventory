using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartInventory.Home.CommonFunc
{
    public class PageBase : System.Web.UI.Page
    {
        public string StoreUserName = string.Empty;
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (RouteData.Values["StoreUserName"] != null)
            {
                StoreUserName = RouteData.Values["StoreUserName"].ToString();
            }
        }
    }
}
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartInventory.Home.Settings
{
    public partial class Setting : CommonFunc.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssignedUrl();
        }

        private void AssignedUrl()
        {
            lnkCategories.HRef = "~/" + StoreUserName + PageURL.ListCategories;
            lnkConfigurations.HRef = "~/" + StoreUserName + PageURL.Configurations;
        }
    }
}
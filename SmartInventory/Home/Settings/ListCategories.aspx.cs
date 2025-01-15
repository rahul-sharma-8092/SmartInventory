using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Interop;

namespace SmartInventory.Home.Settings
{
    public partial class ListCategories : CommonFunc.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AddUpdateCategory"] != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{Session["AddUpdateCategory"]}', 'error');", true);
                Session["AddUpdateCategory"] = null;
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/" + StoreUserName + Common.PageURL.AddUpdateCategories);
        }
    }
}
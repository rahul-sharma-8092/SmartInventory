using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartInventory.Home.Settings
{
    public partial class AddUpdateCategories : CommonFunc.PageBase
    {
        int CategoryID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    hdnCategoryId.Value = Request.QueryString["Id"].Trim();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] userData = GetUserData();
            Categories category = new Categories();
            category.CategoryID = string.IsNullOrEmpty(hdnCategoryId.Value) ? 0 : Convert.ToInt32(hdnCategoryId.Value);
            category.CategoryName = txtCategoryName.Text;
            category.Description = txtDescription.Text;
            category.ParentCategoryID = ddlParentCategory.SelectedValue;
            category.IsActive = chkIsActive.Checked;
            category.StoreUserId = Convert.ToInt32(userData[0]);
            category.UserName = userData[1];

            int result = BAL.SettingsMgt.AddUpdateCategory(category, StoreUserName);
            if (result > 0 )
            {
                Session["AddUpdateCategory"] = category.CategoryID > 0 ? Common.Message.CategoryUpdated : Common.Message.CategoryAdded;
                Response.Redirect("~/" + StoreUserName + PageURL.ListCategories);
            }
            else
            {
                string msg = category.CategoryID > 0 ? Common.Message.CategoryNotAdded : Common.Message.CategoryNotUpdated;
                msg = result == -1 ? Common.Message.DuplicateCategory : msg;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", $"showNotification('{msg}', 'error');", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["AddUpdateCategory"] = null;
            Response.Redirect("~/" + StoreUserName + PageURL.ListCategories);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Common;
using Newtonsoft.Json;

namespace SmartInventory.Home.Handler
{
    /// <summary>
    /// Handler for managing ajax request for setting related page
    /// </summary>
    public class Setting : IHttpHandler
    {
        int RequestType = 0, statusCode = 200;
        string StoreUserName = "", response = "", jsonString = "";
        bool IsAuthenticated = false;

        public void ProcessRequest(HttpContext context)
        {
            response = JsonConvert.SerializeObject(new { data = "", success = false });
            context.Response.ContentType = "application/json";

            RequestType = Convert.ToInt32(context.Request.QueryString["RequestType"]);
            StoreUserName = Convert.ToString(context.Request.QueryString["StoreUserName"]).Trim() ?? "";
            jsonString = new StreamReader(context.Request.InputStream).ReadToEnd();

            var requestData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            if (context.User != null && context.User.Identity.IsAuthenticated)
            {
                string userStoreName = ((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData.Split('|')[4] ?? "";

                if (!string.IsNullOrEmpty(userStoreName) && !string.IsNullOrEmpty(StoreUserName) && userStoreName.Trim().ToLower() == StoreUserName.Trim().ToLower())
                {
                    IsAuthenticated = true;
                }
            }

            if (!IsAuthenticated || string.IsNullOrEmpty(StoreUserName) || StoreUserName.ToLower() == "null" || StoreUserName.ToLower() == "undefined")
            {
                context.Response.StatusCode = 403;
                context.Response.Write(response);
                context.Response.End();
            }

            if (RequestType == (int)SettingHandler.GetCategories) // GetCategories
            {
                DataTable data = BAL.SettingsMgt.GetCategories(StoreUserName);
                response = JsonConvert.SerializeObject(data);
            }
            else if (RequestType == (int)SettingHandler.DeleteCategory) // DeleteCategory
            {
                int id = Convert.ToInt32(requestData["id"]);
                string message = BAL.SettingsMgt.DeleteCategory(id, StoreUserName);
                if (!string.IsNullOrEmpty(message))
                {
                    message = $"Category <b>{message.Trim()}</b> deleted successfully";
                    response = JsonConvert.SerializeObject(new { data = message, success = true });
                }
                else
                {
                    message = "Category deletion fail.";
                    response = JsonConvert.SerializeObject(new { data = message, success = false });
                }
            }

            context.Response.StatusCode = statusCode;
            context.Response.Write(response);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
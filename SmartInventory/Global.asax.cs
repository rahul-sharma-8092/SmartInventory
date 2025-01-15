using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace SmartInventory
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);  
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            Uri url = HttpContext.Current.Request.Url;
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current));

            if (routeData != null && routeData.Values["StoreUserName"] != null)
            {
                string storeUserName = routeData.Values["StoreUserName"].ToString();

                // Store it in HttpContext or use it directly
                HttpContext.Current.Items["StoreUserName"] = storeUserName;
            }
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string storeUserName = HttpContext.Current.Items["StoreUserName"] as string ?? "";
            string userStoreName = GetUserData()[4];

            if (!string.IsNullOrEmpty(storeUserName) && !string.IsNullOrEmpty(userStoreName))
            {
                if (storeUserName.ToLower().Trim() != userStoreName.ToLower().Trim())
                {
                    FormsAuthentication.SignOut();

                    Response.StatusCode = 403;
                    Response.Redirect("~/" + storeUserName + PageURL.Login + "?StoreNameChange=" + HttpUtility.UrlEncode("1"));
                }
            }
        }

        void Application_End(object sender, EventArgs e)
        {

        }

        void Application_Error(object sender, EventArgs e)
        {
            Uri url = HttpContext.Current.Request.Url;
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                string browser = HttpContext.Current.Request.Browser.Type;
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string userIp = HttpContext.Current.Request.UserHostAddress;

                EmailMsg email = new EmailMsg();
                email.To = "rahulsh8092@gmail.com;";
                email.Subject = "Smart Inventory - Error Notification";
                email.IsHtml = true;

                string templatePath = HttpContext.Current.Server.MapPath("~/Template/Email/ErrorMail.html");
                string htmlTemplate = File.ReadAllText(templatePath);

                email.Body = htmlTemplate
                    .Replace("{{time}}", time)
                    .Replace("{{url}}", url.ToString())
                    .Replace("{{browser}}", browser)
                    .Replace("{{userIp}}", userIp)
                    .Replace("{{errorMessage}}", ex.Message.ToString())
                    .Replace("{{innerException}}", Convert.ToString(ex.InnerException) ?? "N/A")
                    .Replace("{{stackTrace}}", Convert.ToString(ex.StackTrace));

                Common.EmailService.SendEmail(email);
               
                string StoreUserName = HttpContext.Current.Items["StoreUserName"] as string ?? "";

                if (!string.IsNullOrEmpty(StoreUserName))
                {
                    ExecptionErrror obj = new ExecptionErrror();
                    obj.StoreUserName = StoreUserName;
                    obj.Message = Convert.ToString(ex.Message) ?? "";
                    obj.InnerException = Convert.ToString(ex.InnerException) ?? "N/A";
                    obj.StackTrace = Convert.ToString(ex.StackTrace) ?? "";
                    obj.URL = Convert.ToString(url) ?? "";
                    obj.IpAddress = userIp;
                    obj.Browser = browser;

                    BAL.ErrorMgt.LogErrorToDB(obj);
                }

                Server.ClearError();
                
                Response.StatusCode = 500;
                //Response.Redirect("~/" + GetStoreUserName() + PageURL.PageNotFound);
            }
        }

        private string GetStoreUserName()
        {
            return HttpContext.Current.Items["StoreUserName"] as string;
        }

        private string[] GetUserData()
        {
            string[] userData = new String[10];
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // StoreUserId|UserName|Email|GroupId|StoreUserName
                // 1001|Tony Stark|tonystark@armyspy.com|1|Zudio
                userData = ((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData.Split('|');
            }
            return userData;
        }
    }
}
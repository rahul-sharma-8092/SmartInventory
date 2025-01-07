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

                Server.ClearError();
                //Response.Redirect("~/" + GetStoreUserName() + PageURL.PageNotFound);
            }
        }

        private string GetStoreUserName()
        {
            return HttpContext.Current.Items["StoreUserName"] as string;
        }
    }
}
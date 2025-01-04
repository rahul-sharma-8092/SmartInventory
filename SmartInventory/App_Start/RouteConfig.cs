using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace SmartInventory
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            //routes.EnableFriendlyUrls(settings);

            routes.Ignore("Content/{*pathInfo}");
            routes.Ignore("Scrpts/{*pathInfo}");
            routes.Ignore("Template/{*pathInfo}");
            routes.Ignore("Home/CSS/{*pathInfo}");
            routes.Ignore("Home/JS/{*pathInfo}");
            routes.Ignore("bundles/{*pathInfo}");

            routes.MapPageRoute(
                "MultiFolderRoute",
                "{StoreUserName}/{*pathInfo}",
            "~/{pathInfo}"
            );
        }
    }
}

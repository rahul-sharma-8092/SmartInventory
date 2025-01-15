using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartInventory.Home.Handler
{
    /// <summary>
    /// Summary description for General
    /// </summary>
    public class General : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
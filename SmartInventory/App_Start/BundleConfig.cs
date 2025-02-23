﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace SmartInventory
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterJQueryScriptManager();

            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                    "~/Scripts/WebForms/WebForms.js",
                    "~/Scripts/WebForms/WebUIValidation.js",
                    "~/Scripts/WebForms/MenuStandards.js",
                    "~/Scripts/WebForms/Focus.js",
                    "~/Scripts/WebForms/GridView.js",
                    "~/Scripts/WebForms/DetailsView.js",
                    "~/Scripts/WebForms/TreeView.js",
                    "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                   "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/JQueryWithCommonJS").Include(
                    "~/Scripts/jquery-3.7.1.min.js",
                    "~/Home/JS/SiteMaster.js",
                    "~/Home/JS/CommonJs.js"));
            
            //Kendo License Key
            bundles.Add(new ScriptBundle("~/bundles/kendoLicxJS").Include(
                    "~/Scripts/Kendo/kendo-ui-license.js"
                    ));

            bundles.Add(new StyleBundle("~/bundles/kendoDefaultCSS").Include(
                    "~/Content/kendo/default-main.css")); // Kendo Default Theme

            bundles.Add(new StyleBundle("~/bundles/kendoDatavizCSS").Include(
                    "~/Content/kendo/default-dataviz-v4.css")); // Data Visualization ex- charts
            
            bundles.Add(new ScriptBundle("~/bundles/SiteMasterJS").Include(
                    "~/Home/JS/SiteMaster.js",
                    "~/Home/JS/CommonJs.js"));

            bundles.Add(new StyleBundle("~/bundles/SiteMasterCSS").Include(
                    "~/Home/CSS/FontDefiniton.css",
                    "~/Home/CSS/SiteMaster.css"));

            BundleTable.EnableOptimizations = true;
        }

        public static void RegisterJQueryScriptManager()
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-3.7.1.min.js",
                    DebugPath = "~/scripts/jquery-3.7.1.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.1.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.1.js"
                });
        }
    }
}
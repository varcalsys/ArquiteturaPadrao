using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region Js
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            var jqueryVal = new ScriptBundle("~/bundles/jquery-validate").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js");

            jqueryVal.Orderer = new AsIsBundleOrderer();
            bundles.Add(jqueryVal);


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-{version}.js"));

            #endregion


            #region Css
            var siteCss = new StyleBundle("~/Content/Site").Include(
                   "~/Content/bootstrap.css",
                   "~/Content/bootstrap-theme.css",
                   "~/Content/site.css");

            siteCss.Orderer = new AsIsBundleOrderer();
            bundles.Add(siteCss); 
            #endregion


#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif

        }
    }

    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
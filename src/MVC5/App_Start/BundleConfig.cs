using System.Collections.Generic;
using System.Web.Optimization;

namespace MVC5
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region js
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            var bootstrap = new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js");
            bootstrap.Orderer = new AsIsBundleOrderer();
            bundles.Add(bootstrap);
            #endregion

            #region css
            var css = new StyleBundle("~/Content/css").Include(
                         "~/Content/bootstrap.css",
                        "~/Content/bootstrap-theme.css",
                         "~/Content/site.css");
            css.Orderer = new AsIsBundleOrderer();
            bundles.Add(css); 
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

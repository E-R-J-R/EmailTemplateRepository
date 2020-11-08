using System.Web;
using System.Web.Optimization;

namespace eCom.Interview.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            const string ANGULAR_APP_ROOT = "~/App/dist/App/";

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Angular
            //var scriptBundle = new ScriptBundle("~/bundles/angular")
            //    .IncludeDirectory(
            //        ANGULAR_APP_ROOT,
            //        searchPattern: "*.js",
            //        searchSubdirectories: true
            //    );
            //bundles.Add(scriptBundle);
        }
    }
}

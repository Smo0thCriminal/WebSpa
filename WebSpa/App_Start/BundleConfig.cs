using System.Web;
using System.Web.Optimization;

namespace WebSpa
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/libs/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/libs/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/libs/bootstrap.js",
                "~/Scripts/libs/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/libs/angular.js",
                "~/Scripts/libs/angular-ui-router.js",
                "~/Scripts/libs/angular-route.js",
                "~/Scripts/libs/angular-resource.min.js",
                "~/Scripts/libs/jquery-1.10.2.js",
                "~/Scripts/libs/bootstrap.min.js",
                "~/Scripts/app/WebSpaApp.js",
                "~/Scripts/app/Controllers/LoginController.js")
                //.IncludeDirectory("~/Scripts/app/Controllers/", "*.js")
                .IncludeDirectory("~/Scripts/app/Services/", "*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}

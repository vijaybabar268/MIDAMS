using System.Web;
using System.Web.Optimization;

namespace MIDAMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //    "~/Scripts/datatables/jquery.datatables.js",
            //    "~/Scripts/datatables/datatables.bootstrap.js",
            //    "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            /* Admin */
            bundles.Add(new StyleBundle("~/Admin/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/datatables/css/datatables.bootstrap.css",
                "~/Areas/Admin/Content/css/AdminSite.css"));

            /*Website*/
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/style1.css",
                      "~/Content/css/jquery.bxslider.css"));

            bundles.Add(new StyleBundle("~/Content/css2").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/datatables/jquery.datatables.js",
                "~/Scripts/datatables/datatables.bootstrap.js",
                "~/Scripts/bootstrap.js",
                "~/Content/js/common.js"));
        }
    }
}

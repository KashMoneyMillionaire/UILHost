using System.Web.Optimization;

namespace UILHost.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax*",
                        "~/Scripts/jquery-migrate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/bundles/custom-css").Include(
                "~/Content/reset.css",
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/kendo/2014.1.318/kendo.common.min.css",
                "~/Content/kendo/2014.1.318/kendo.bootstrap.min.css",
                "~/Content/kendo/2014.1.318/kendo.common-bootstrap.core.min.css",
                "~/Content/velcro.css"
                //"~/Content/style.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/2014.1.318/kendo.core.js",
                        "~/Scripts/kendo/2014.1.318/kendo.web.js",
                        "~/Scripts/knockout/bm.ajaxservice.js",
                        "~/Scripts/benefitmall.pavlos.grid.plugin.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/mask").Include(
                "~/Scripts/jquery.mask.min.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                      "~/Scripts/knockout/bm.ajaxservice.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/pavlos/model").Include(
                      "~/Scripts/pavlos/pavlos.js",
                      "~/Scripts/pavlos/pavlos.numberFormat.js",
                      "~/Scripts/pavlos/pavlos.forms.js",
                      "~/Scripts/pavlos/pavlos.model.core.js",
                      "~/Scripts/pavlos/pavlos.model.util.js",
                      "~/Scripts/pavlos/pavlos.validation.js",
                      "~/Scripts/pavlos/pavlos.maintenanceGrid.plugin.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
                "~/Scripts/bootbox.js"));
        }
    }
}

using System.Web;
using System.Web.Optimization;

namespace Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                      ));

            //BEGIN GLOBAL MANDATORY STYLES
            bundles.Add(new StyleBundle("~/MetronicGlobalMandatory/css").Include(
                     "~/Metronic/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                     "~/Metronic/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                      "~/Metronic/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                      "~/Metronic/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
                      ));
            //END BEGIN GLOBAL MANDATORY STYLES

            //BEGIN THEME GLOBAL STYLES
            bundles.Add(new StyleBundle("~/MetronicGlobalStyles/css").Include(
                     "~/Metronic/assets/global/css/components.min.css",
                     "~/Metronic/assets/global/css/plugins.min.css"
                      ));
            //END BEGIN THEME GLOBAL STYLES

            //BEGIN THEME LAYOUT STYLES
            bundles.Add(new StyleBundle("~/MetronicLayoutStyle/css").Include(
                     "~/Metronic/assets/layouts/layout3/css/layout.min.css",
                     "~/Metronic/assets/layouts/layout3/css/themes/default.min.css",
                      "~/Metronic/assets/layouts/layout3/css/custom.min.css"
                      ));
            //END BEGIN THEME LAYOUT STYLES

            bundles.Add(new StyleBundle("~/Content/animate/css").Include(
                "~/Content/animate.min.css"
                ));

            //BEGIN CORE PLUGINS
            bundles.Add(new ScriptBundle("~/bundles/metronicCorePlugin/js").Include(
                  //"~/Metronic/assets/global/plugins/jquery.min.js",
                  //"~/Metronic/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                  "~/Metronic/assets/global/plugins/js.cookie.min.js",
                  "~/Metronic/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                  "~/Metronic/assets/global/plugins/jquery.blockui.min.js",
                  "~/Metronic/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
                ));
            //END CORE PLUGINS

            //BEGIN THEME GLOBAL SCRIPTS
            bundles.Add(new ScriptBundle("~/bundles/metronicThemeGlobal/js").Include(
                  "~/Metronic/assets/global/scripts/app.min.js"
                ));
            //END BEGIN THEME GLOBAL SCRIPTS

            //BEGIN THEME LAYOUT SCRIPTS
            bundles.Add(new ScriptBundle("~/bundles/metronicThemeLayout/js").Include(
                  "~/Metronic/assets/layouts/layout3/scripts/layout.min.js",
                  "~/Metronic/assets/layouts/layout3/scripts/demo.min.js",
                  "~/Metronic/assets/layouts/global/scripts/quick-sidebar.min.js",
                  "~/Metronic/assets/layouts/global/scripts/quick-nav.min.js"
                ));
            //END BEGIN THEME LAYOUT SCRIPTS

            //BEGIN ANIMATE
            bundles.Add(new ScriptBundle("~/bundles/animate/js").Include(
                "~/Scripts/animate.min.js"
                ));
            //END ANIMATE

        }
    }
}

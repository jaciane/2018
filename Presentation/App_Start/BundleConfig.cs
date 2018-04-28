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

            //BEGIN PAGE LEVEL PLUGINS
            bundles.Add(new ScriptBundle("~/MetronicSelect2/css").Include(
            "~/Metronic/assets/global/plugins/select2/css/select2.min.css",
            "~/Metronic/assets/global/plugins/select2/css/select2-bootstrap.min.css"));
            //END PAGE LEVEL PLUGINS

            //BEGIN PAGE LEVEL PLUGINS
            bundles.Add(new ScriptBundle("~/MetronicLogin/css").Include(
            "~/Metronic/assets/pages/css/login-3.min.css"));
            //END PAGE LEVEL PLUGINS

            //BEGIN CORE PLUGINS
            bundles.Add(new ScriptBundle("~/bundles/metronicCorePlugin/js").Include(
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

            //BEGIN JQUERY INPUTMASK
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            "~/Scripts/inputmask/inputmask.js",
            "~/Scripts/Inputmask/jquery.inputmask.js",
            "~/Scripts/Inputmask/inputmask.extensions.js",
            "~/Scripts/Inputmask/inputmask.date.extensions.js",
            "~/Scripts/Inputmask/inputmask.numeric.extensions.js"));
            //END JQUERY INPUTMASK

            //BEGIN PAGE LEVEL PLUGINS
            bundles.Add(new ScriptBundle("~/MetronicLogin/js").Include(
            "~/Metronic/assets/pages/scripts/login.min.js"));
            //END PAGE LEVEL PLUGINS

            //BEGIN PAGE LEVEL PLUGINS
            bundles.Add(new ScriptBundle("~/MetronicLoginAdditional/js").Include(
            "~/Metronic/assets/global/plugins/jquery-validation/js/additional-methods.min.js",
             "~/Metronic/assets/global/plugins/jquery-validation/js/select2.full.min.js"
            ));
            //END PAGE LEVEL PLUGINS

        }
    }
}

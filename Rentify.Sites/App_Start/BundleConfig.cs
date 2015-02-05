using System.Web;
using System.Web.Optimization;

namespace Rentify.Sites
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/theme/lavilla").Include(
                      "~/Scripts/Themes/lavilla/hoverIntent.js",
                      "~/Scripts/Themes/lavilla/superfish.min.js",
                      "~/Scripts/Themes/lavilla/jquery.customSelect.min.js",
                      "~/Scripts/Themes/lavilla/jquery-ui.min.js",
                      "~/Scripts/Themes/lavilla/masonry.min.js",
                      "~/Scripts/Themes/lavilla/jquery.form-validator.min.js",
                      "~/Scripts/Themes/lavilla/lavilla-datepick.js",
                      "~/Scripts/Themes/lavilla/owl.carousel.js",
                      "~/Scripts/Themes/lavilla/lavilla-functions.js"
                      ));

            bundles.Add(new StyleBundle("~/css/theme/lavilla").Include(
                      "~/Css/Themes/lavilla/reset.css",
                      "~/Css/Themes/lavilla/styles.css",
                      "~/Css/Themes/lavilla/responsive-grid.default.css",
                      "~/Css/Themes/lavilla/responsive-grid.big-desktop.css",
                      "~/Css/Themes/lavilla/colours.blue-orange.css",
                      "~/Css/Themes/lavilla/datepicker.css",
                      "~/Css/Themes/lavilla/owl.carousel.css",
                      "~/Css/Themes/lavilla/owl.theme.css",
                      "~/Css/Themes/lavilla/owl.transitions.css"
                      ));

        }
    }
}

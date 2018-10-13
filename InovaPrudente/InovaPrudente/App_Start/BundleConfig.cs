using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace InovaPrudente
{
    public class BundleConfig
    {
        public class AsIsBundleOrderer : IBundleOrderer
        {
            public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
            {
                return (files);
            }
        }

        public class CssRewriteUrlTransformWrapper : IItemTransform
        {
            public string Process(string includedVirtualPath, string input)
            {
                return new CssRewriteUrlTransform().Process("~" + VirtualPathUtility.ToAbsolute(includedVirtualPath), input);
            }
        }

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            Bundle css = new Bundle("~/Content/css/bundle")
                .Include("~/node_modules/bootstrap/dist/css/bootstrap.css", new CssRewriteUrlTransformWrapper())
                .Include("~/node_modules/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransformWrapper())
                .Include("~/node_modules/animate.css/animate.css")
                .Include("~/node_modules/pnotify/dist/pnotify.css")
                .Include("~/node_modules/pnotify/dist/pnotify.mobile.css")
                .Include("~/node_modules/pnotify/dist/pnotify.buttons.css")
                .Include("~/Content/css/flatly.css")
                .Include("~/Content/css/site.css");

            css.Orderer = new AsIsBundleOrderer();
            bundles.Add(css);

            bundles.Add(new Bundle("~/bundles/LayoutJs").Include(
                        "~/node_modules/jquery/dist/jquery.js",
                        "~/node_modules/bootstrap/dist/js/bootstrap.bundle.js",
                        "~/node_modules/pnotify/dist/pnotify.js",
                        "~/node_modules/pnotify/dist/pnotify.animate.js",
                        "~/node_modules/pnotify/dist/pnotify.buttons.js",
                        "~/node_modules/pnotify/dist/pnotify.desktop.js",
                        "~/node_modules/pnotify/dist/pnotify.mobile.js",
                        "~/Scripts/App/dist/backdropLoadingModulo.js",
                        "~/Scripts/App/dist/mensagensModulo.js",
                        "~/Scripts/App/dist/index.js"));

            BundleTable.EnableOptimizations = !HttpContext.Current.IsDebuggingEnabled;
        }
    }
}
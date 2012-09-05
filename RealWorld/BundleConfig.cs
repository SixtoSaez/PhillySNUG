using System.Web.Optimization;

namespace RealWorld
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.*",
                "~/Scripts/jquery-ui-{version}.js")
                );

            bundles.Add(new ScriptBundle("~/Scripts/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout-deferred-updates.js")
                );

            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                "~/Scripts/modernizr-{version}-development-only.js")
                );
        }
    }
}
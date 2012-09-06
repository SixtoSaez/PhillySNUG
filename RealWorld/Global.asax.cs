using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RealWorld
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// Configure both the MVC & Web API sides of the application
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterMvcRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        
            // WebApi Configuration to configure formatters:
            RemoveUnneededMediaTypes(GlobalConfiguration.Configuration);
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        private static void RegisterMvcRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Error",
                url: "Error/{returnUrl}",
                defaults: new { controller = "Home", action = "Error", returnUrl = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        private static void RemoveUnneededMediaTypes(HttpConfiguration config)
        {
            // remove default forms url encoded handler
            var matches = config.Formatters
                .Where(f => f.SupportedMediaTypes.Any(
                    m => m.MediaType.StartsWith("application/x-www-form-url")))
                .ToList();

            foreach (var match in matches)
                config.Formatters.Remove(match);
        }
    }
}
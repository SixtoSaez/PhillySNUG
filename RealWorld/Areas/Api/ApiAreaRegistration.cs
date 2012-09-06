using System.Web.Http;
using System.Web.Mvc;

namespace RealWorld.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // Explicitly set valid routes to controllers:
            context.Routes.MapHttpRoute(
                name: "LoginApi",
                routeTemplate: "api/Login",
                defaults: new {controller = "Login" });

            context.Routes.MapHttpRoute(
                name: "SomeProcessApi",
                routeTemplate: "api/SomeProcess",
                defaults: new { controller = "SomeProcess" });
        }
    }
}

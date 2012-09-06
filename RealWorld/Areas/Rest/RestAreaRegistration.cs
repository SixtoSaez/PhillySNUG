using System.Web.Http;
using System.Web.Mvc;

namespace RealWorld.Areas.Rest
{
    public class RestAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Rest";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                name: "LoginRest",
                routeTemplate: "rest/LoginWithLinks",
                defaults: new {controller = "LoginWithLinks" } );


            context.Routes.MapHttpRoute(
                name: "SomeProcessRest",
                routeTemplate: "rest/SomeProcessWithLinks",
                defaults: new { controller = "SomeProcessWithLinks" });
        }
    }
}

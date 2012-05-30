using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace RealWorld.Application
{
    public class ApiAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                var httpContext = ((HttpContextWrapper) request.Properties["MS_HttpContext"]);
                var authCookie = httpContext.Request.Cookies["AppAuthentication"];

                if (authCookie == null || authCookie.Value != "someSuperCoolEncryptedValue")
                {
                    var unauthorizedMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                                  {
                                      Content = new StringContent("Sorry, you don't know the super secret password.")
                                  };

                    throw new HttpResponseException(unauthorizedMessage);
                }
            }
        }
    }
}
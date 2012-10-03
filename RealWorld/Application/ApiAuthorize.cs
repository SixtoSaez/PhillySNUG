using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace RealWorld.Application
{
    /// <summary>
    /// Authorization logic for the ASP.NET MVC 4 side of the application
    /// </summary>
    public class ApiAuthorize : AuthorizeAttribute
    {
        /*
         * 
         * If you get the error: "Cannot redirect after HTTP headers have been sent."
         * when failing authentication, then it is very likely IIS is set to enable
         * Forms authentication which is configured to perform a 302 redirect to
         * a URI like "~/Account/Login". To remove this error, disable Forms
         * authentication or replace with something like Phil Haaked show here:
         * 
         * http://haacked.com/archive/2011/10/04/prevent-forms-authentication-login-page-redirect-when-you-donrsquot-want.aspx
         * 
         */

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException("actionContext");

            var authCookie = actionContext.Request.Headers.GetCookies("AppAuthentication");

            if (authCookie == null || authCookie[0].Cookies[0].Value != "someSuperCoolEncryptedValue")
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException("actionContext");

            actionContext.Response = CreateUnauthorizedResponse(actionContext.ControllerContext.Request);
        }

        private HttpResponseMessage CreateUnauthorizedResponse(HttpRequestMessage request)
        {
            var result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                RequestMessage = request
            };

            return result;
        }
    }
}
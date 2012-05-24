using System.Web;
using System.Web.Mvc;

namespace RealWorld.Application
{
    public class WebAuthorize : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var authCookie = filterContext.HttpContext.Request.Cookies["AppAuthentication"];

            if (authCookie == null || authCookie.Value != "someSuperCoolEncryptedValue")
            {
                var returnUrl = HttpUtility.UrlEncode(filterContext.HttpContext.Request.RawUrl);
                filterContext.Result = new RedirectResult(string.Format("/Error?returnUrl={0}", returnUrl));
            }
        }
    }
}
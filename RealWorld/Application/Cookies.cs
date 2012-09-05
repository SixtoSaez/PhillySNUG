using System;
using System.Web;

namespace RealWorld.Application
{
    /// <summary>
    /// Simple class to create authentication cookies. Provided as
    /// a sample of how to implement cookie based authentication
    /// using the ASP.NET Web API
    /// </summary>
    public static class Cookies
    {
        public static HttpCookie CreateAuthCookie()
        {
            var authCookie = new HttpCookie("AppAuthentication");
            authCookie.Expires = DateTime.Now.AddSeconds(30);
            authCookie.Value = "someSuperCoolEncryptedValue";
            return authCookie;
        }
    }
}
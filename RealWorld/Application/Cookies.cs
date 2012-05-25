using System;
using System.Web;

namespace RealWorld.Application
{
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
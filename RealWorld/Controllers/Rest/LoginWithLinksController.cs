using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using RealWorld.Application;
using RealWorld.Models;
using System.Collections.Generic;

namespace RealWorld.Controllers.Rest
{
    /// <summary>
    /// Entry point in the Web API application. Provides for authentication
    /// and basic application information. Also, returns possible actions (links)
    /// the client application (user agent) can trigger
    /// </summary>
    public class LoginWithLinksController : ApiController
    {
        // GET /api/login
        /// <summary>
        /// Entry point for the authentication process.
        /// </summary>
        /// <returns>An empty instance of the credential representation to be POSTed for authention with the appropriate URI</returns>
        public LinkedCredentials Get()
        {
            const string linkUrl = "~/rest/loginwithlinks";
            var responseUrl = GetAbsoluteLink(linkUrl);

            return new LinkedCredentials
                       {
                           Links = new[] {new AppLink
                                              {
                                                  Description = "Login URI for authentication",
                                                  Href = responseUrl,
                                                  Method = "POST",
                                                  Rel = "SignIn"
                                              }}
                       };
        }

        // POST /api/login
        /// <summary>
        /// Authentication end point to provide client application credentials
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>HTTP Status 200 if credentials accepted and appropriate links for the next steps in the process or HTTP Status 401 if unathorized.</returns>
        public HttpResponseMessage Post(LinkedCredentials credentials)
        {
            HttpResponseMessage message;
            //TODO: please use a real and secure authentication scheme!!
            if (credentials.Password == "Bad")
            {
                message = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                message.Content = new StringContent("Credentials were bad, bad, bad!");
            }
            else
            {
                //TODO: please use a real and secure authentication scheme!!
                credentials.Password = "IsSignedInWithLinking";
                const string linkUrl = "~/rest/someprocesswithlinks";
                credentials.Links = new List<AppLink>
                                        {
                                            new AppLink
                                                {
                                                    Description = "Some Process available to this login",
                                                    Href = GetAbsoluteLink(linkUrl),
                                                    Method = "GET",
                                                    Rel = "TriggerSomeProcess"
                                                }
                                        };

                message = new HttpResponseMessage(HttpStatusCode.OK);
                message.Content = new ObjectContent<LinkedCredentials>(
                    credentials,
                    GlobalConfiguration.Configuration.Formatters.JsonFormatter);

                //For demo purposes only: don't this at home!!!
                var authCookie = Cookies.CreateAuthCookie();
                const string setCookie = "{0}={1}; expires={2:ddd, dd MMM yyyy} {3:HH:mm:ss} GMT; path=/";
                message.Headers.Add("Set-Cookie", string.Format(
                    setCookie,
                    authCookie.Name,
                    authCookie.Value,
                    DateTime.Now,
                    DateTime.UtcNow.AddMinutes(10)));
            }
            return message;
        }

        private static string GetAbsoluteLink(string linkUrl)
        {

            var requestUrl = HttpContext.Current.Request.Url;
            string responseUrl;
            if (requestUrl.Host.StartsWith("localhost", StringComparison.CurrentCultureIgnoreCase))
            {
                //Only add port for localhost:
                responseUrl = String.Format("{0}://{1}:{2}{3}",
                    requestUrl.Scheme,
                    requestUrl.Host,
                    requestUrl.Port,
                    VirtualPathUtility.ToAbsolute(linkUrl));
            }
            else
            {
                responseUrl = String.Format("{0}://{1}{2}",
                    requestUrl.Scheme,
                    requestUrl.Host,
                    VirtualPathUtility.ToAbsolute(linkUrl));
            }
            return responseUrl;
        }

        // PUT /api/login/5 ** Not applicable to this resource

        // DELETE /api/login/5 ** Not applicable to this resource
    }
}
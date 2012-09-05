using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealWorld.Application;
using RealWorld.Models;

namespace RealWorld.Controllers.Api
{
    /// <summary>
    /// Entry point in the Web API application. Provides for authentication
    /// and basic application information
    /// </summary>
    public class LoginController : ApiController
    {
        // GET /api/login
        /// <summary>
        /// Entry point for the authentication process.
        /// </summary>
        /// <returns>An empty instance of the credential representation to be POSTed for authention</returns>
        public Credentials Get()
        {
            return new Credentials();
        }

        // POST /api/login
        /// <summary>
        /// Authentication end point to provide client application credentials
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>HTTP Status 200 if credentials accepted or HTTP Status 401 if unathorized</returns>
        public HttpResponseMessage Post(Credentials credentials)
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
                credentials.Password = "IsSignedInSoWeDon'tWantToEchoIt";

                message = new HttpResponseMessage(HttpStatusCode.OK);
                message.Content = new ObjectContent<Credentials>(
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

        // PUT /api/login/5 ** Not applicable to this resource

        // DELETE /api/login/5 ** Not applicable to this resource
    }
}
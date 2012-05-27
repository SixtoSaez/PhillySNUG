using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealWorld.Application;
using RealWorld.Models;

namespace RealWorld.Controllers.Api
{
    public class LoginController : ApiController
    {
        // GET /api/login
        public Credentials Get()
        {
            return new Credentials();
        }

        // POST /api/login
        public HttpResponseMessage Post(Credentials credentials)
        {
            //TODO: please use a real and secure authentication scheme!!
            credentials.Password = "IsSignedInSoWeDon'tWantToEchoIt";
          
            var message = new HttpResponseMessage<Credentials>(credentials, HttpStatusCode.OK);
            
            //For demo purposes only: don't this at home!!!
            var authCookie = Cookies.CreateAuthCookie();
            const string setCookie = "{0}={1}; expires={2:ddd, dd MMM yyyy} {3:HH:mm:ss} GMT; path=/";
            message.Headers.Add("Set-Cookie", string.Format(
                setCookie,
                authCookie.Name,
                authCookie.Value,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)));

            return message;
        }

        // PUT /api/login/5 ** Not applicable to this resource

        // DELETE /api/login/5 ** Not applicable to this resource
    }
}
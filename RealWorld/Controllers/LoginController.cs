using System.Web.Http;
using RealWorld.Models;

namespace RealWorld.Controllers
{
    public class LoginController : ApiController
    {
        // GET /api/login
        public Credentials Get()
        {
            return new Credentials();
        }

        // POST /api/login
        public void Post(Credentials credentials)
        {

        }

        // PUT /api/login/5 ** Not applicable to this resource

        // DELETE /api/login/5 ** Not applicable to this resource
    }
}
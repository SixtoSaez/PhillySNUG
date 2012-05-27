using System.Web.Http;
using RealWorld.Models;

namespace RealWorld.Controllers.Api
{
    public class SomeProcessController : ApiController
    {
        public BizProcessStatus Get()
        {
            return new BizProcessStatus { Status = "All is B2B good" };
        }
    }
}

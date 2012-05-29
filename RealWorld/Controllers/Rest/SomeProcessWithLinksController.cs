using System.Collections.Generic;
using System.Web.Http;
using RealWorld.Models;

namespace RealWorld.Controllers.Rest
{
    public class SomeProcessWithLinksController : ApiController
    {
        public BizProcessStatus Get()
        {
            return new BizProcessStatus
                       {
                           Status = "All is B2B good with linking",
                           ProcessingDetails = new List<string> { "this detail link", "that detail link"}
                       };
        }
    }
}

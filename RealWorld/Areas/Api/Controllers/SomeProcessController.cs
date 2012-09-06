using System.Collections.Generic;
using System.Web.Http;
using RealWorld.Application;
using RealWorld.Models;

namespace RealWorld.Areas.Api.Controllers
{
    /// <summary>
    /// Gets the status of the business process and provides static details
    /// </summary>
    [ApiAuthorize]
    public class SomeProcessController : ApiController
    {
        public BizProcessStatus Get()
        {
            return new BizProcessStatus
                       {
                           Status = "All is B2B good",
                           ProcessingDetails = new List<string> { "this detail", "that detail"}
                       };
        }
    }
}

using System.Collections.Generic;
using System.Web.Http;
using RealWorld.Application;
using RealWorld.Areas.Rest.Models;

namespace RealWorld.Areas.Rest.Controllers
{
    /// <summary>
    /// Gets the status of the business process and provides details
    /// with access to the specific detail resources
    /// </summary>
    [ApiAuthorize]
    public class SomeProcessWithLinksController : ApiController
    {
        /// <summary>
        /// Gets summary information for a business process
        /// </summary>
        /// <returns>The status and a list of detail links</returns>
        public LinkedBizProcessStatus Get()
        {
            return new LinkedBizProcessStatus
                       {
                           Status = "All is B2B good with linking",
                           ProcessingDetails = new List<AppLink> {
                               new AppLink {
                                   Description = "this detail link",
                                   Href="http://somevalidhost/rest/processResource/1",
                                   Method="GET",
                                   Rel="self"
                               },
                               new AppLink {
                                   Description = "that detail link",
                                   Href="http://somevalidhost/rest/processResource/2",
                                   Method="GET",
                                   Rel="self"
                               }
                           }
                       };
        }
    }
}

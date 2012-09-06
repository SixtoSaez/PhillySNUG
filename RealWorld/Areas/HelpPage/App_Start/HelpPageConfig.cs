using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using RealWorld.Areas.Rest.Models;
using RealWorld.Models;

namespace RealWorld.Areas.HelpPage
{
    /// <summary>
    /// Use this class to customize the Help Page.
    /// For example you can set a custom <see cref="System.Web.Http.Description.IDocumentationProvider"/> to supply the documentation
    /// or you can provide the samples for the requests/responses.
    /// </summary>
    public static class HelpPageConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Set to use the documentation from XML documentation file.
            config.SetDocumentationProvider(
                new XmlDocumentationProvider(
                    HttpContext.Current.Server.MapPath("~/App_Data/RealWorld.xml")));

            //// Uncomment the following to use "sample string" as the sample for all actions that have string as the body parameter or return type.
            //// Also, the string arrays will be used for IEnumerable<string>. The sample objects will be serialized into different media type 
            //// formats by the available formatters.
            //config.SetSampleObjects(new Dictionary<Type, object>
            //{
            //    {typeof(string), "sample string"},
            //    {typeof(IEnumerable<string>), new string[]{"sample 1", "sample 2"}}
            //});

            //// Uncomment the following to use "[0]=foo&[1]=bar" directly as the sample for all actions that support form URL encoded format
            //// and have IEnumerable<string> as the body parameter or return type.
            //config.SetSampleForType("[0]=foo&[1]=bar", new MediaTypeHeaderValue("application/x-www-form-urlencoded"), typeof(IEnumerable<string>));

            //// Uncomment the following to use "1234" directly as the request sample for media type "text/plain" on the controller named "Values" 
            //// and action named "Put".
            //config.SetSampleRequest("1234", new MediaTypeHeaderValue("text/plain"), "Values", "Put");

            //// Uncomment the following to use the image on "../images/aspNetHome.png" directly as the response sample for media type "image/png"
            //// on the controller named "Values" and action named "Get" with parameter "id".
            //config.SetSampleResponse(new ImageSample("../images/aspNetHome.png"), new MediaTypeHeaderValue("image/png"), "Values", "Get", "id");

            //// Uncomment the following to correct the sample request when the action expects an HttpRequestMessage with ObjectContent<string>.
            
            config.SetActualRequestType(typeof(LinkedCredentials), "LoginWithLinksController", "Post");
            config.SetSampleObjects(
                new Dictionary<Type, object>
                    {
                        {
                            typeof (LinkedCredentials),
                            new LinkedCredentials
                                {
                                    UserName = "John",
                                    Password = "some password",
                                    Links = new[]
                                                {
                                                    new AppLink
                                                        {
                                                            Rel =
                                                                "http://appDomain/schema/getOrders",
                                                            Href = "http://appDomain/api/orders/john",
                                                            Method = "GET",
                                                            Description = "Get orders for this user"
                                                        },
                                                                                                            new AppLink
                                                        {
                                                            Rel =
                                                                "http://appDomain/schema/getOrderHistory",
                                                            Href = "http://appDomain/api/orderhistory/john/{cutoffDate}",
                                                            Method = "GET",
                                                            Description = "Get order history through this cutoff date"
                                                        }

                                                }
                                }
                            }
                    });
        }
    }
}
